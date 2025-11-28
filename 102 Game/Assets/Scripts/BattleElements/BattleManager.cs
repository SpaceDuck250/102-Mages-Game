using UnityEngine;
using System.Collections;
using System;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public PlayerScript player;
    WordGiver wordGiver;

    public Battler currentBattler;

    public bool isPlayersTurn;

    public event Action<Battler> onPlayerWin;
    public event Action<Battler> onPlayerLose;

    public event Action<float, Battler> onPlayerAttack;
    public event Action<float, Battler> onEnemyAttack;

    public event Action<Battler> onBattleStart;
    public event Action<Battler> onBattleEnd;

    private BlockAttackScript blockAttackScript;
    [SerializeField]
    private bool blocked = false;


    private void Awake()
    {
        instance = this;
        player = GameManager.instance.player;
        wordGiver = GameManager.instance.wordGiver;

    }

    private void Start()
    {
        blockAttackScript = GetComponent<BlockAttackScript>();
        blockAttackScript.onBlock += OnBlock;
        blockAttackScript.onUnblock += OnUnblock;
    }

    private void OnDestroy()
    {
        blockAttackScript.onBlock -= OnBlock;
        blockAttackScript.onUnblock -= OnUnblock;
    }

    private void OnUnblock()
    {
        blocked = false;
    }

    private void OnBlock(float blockTime)
    {
        blocked = true;
    }

    public IEnumerator CommenceBattle(Battler newBattler)
    {
        currentBattler = newBattler;
        RevivePlayerAndBattler();

        isPlayersTurn = true;

        onBattleStart?.Invoke(currentBattler);

        float loadingTime = 4.15f;
        yield return new WaitForSeconds(loadingTime);

        StartCoroutine(GivePlayerWordToType()); // This will start the cycle back and forth between the player and the battler
    }

    public void RevivePlayerAndBattler()
    {
        HealthScript battlerHealthComponent = currentBattler.gameObject.GetComponent<HealthScript>();
        battlerHealthComponent.Revive();

        HealthScript playerHealthComponent = player.gameObject.GetComponent<HealthScript>();
        playerHealthComponent.Revive();
    }

    void EndBattle()
    {
        currentBattler = null;
        CommandProcessor.instance.battleMode = false;

        onBattleEnd?.Invoke(currentBattler);
    }

    public void OnBattlerDeath() // Win
    {
        onPlayerWin?.Invoke(currentBattler);

        Battle battleComponent = currentBattler.gameObject.GetComponent<Battle>();
        NodeScript winNode = battleComponent.winNode;
        winNode.SetNodeToCurrentNode();

        EndBattle();
    }

    public void OnPlayerDeath() // Lose
    {
        onPlayerLose?.Invoke(currentBattler);

        Battle battleComponent = currentBattler.gameObject.GetComponent<Battle>();
        NodeScript lostNode = battleComponent.lostNode;
        lostNode.SetNodeToCurrentNode();

        EndBattle();
    }

    public IEnumerator LetBattlerAttack() // Then check if the player died
    {
        float waitTime = 1.75f;
        yield return new WaitForSeconds(waitTime);

        float damageDelt = currentBattler.PickDamageValue();
        DealDamageTo(damageDelt, player.gameObject);

        onEnemyAttack?.Invoke(damageDelt, currentBattler);

        CheckWhosTurnAndSwitch();
    }

    public void LetPlayerAttack(float timeTaken, int wordCount)
    {
        float damageDelt = CalculatePlayerDamage(timeTaken, wordCount);
        DealDamageTo(damageDelt, currentBattler.gameObject);

        onPlayerAttack?.Invoke(damageDelt, currentBattler);


        CheckWhosTurnAndSwitch();
    }

    void DealDamageTo(float damage, GameObject obj)
    {
        if (blocked && obj.tag == "Player")
        {
            return;
        }

        HealthScript healthComponent = obj.GetComponent<HealthScript>();
        healthComponent.TakeDamage(damage);

        if (healthComponent.dead && obj.tag == "Player")
        {
            OnPlayerDeath();
            return;

        }
        else if (healthComponent.dead)
        {
            OnBattlerDeath();
            return;
        }
    }

    public IEnumerator GivePlayerWordToType() // Then check if the battler died
    {
        float waitTime = 1.2f;
        yield return new WaitForSeconds(waitTime);
        wordGiver.GenerateWordChallenge();
    }

    public void CheckWhosTurnAndSwitch()
    {
        if (!CommandProcessor.instance.battleMode)
        {
            return;
        }

        isPlayersTurn = !isPlayersTurn;
        if (isPlayersTurn)
        {
            StartCoroutine(GivePlayerWordToType());
        }
        else
        {
            StartCoroutine(LetBattlerAttack());
        }
    }

    public float CalculatePlayerDamage(float timeTaken, float wordCount)
    {
        if (timeTaken == 0) // ig cheating and the case where they reached deadline its set to 0
        {
            return 0;
        }

        float wpm = wordCount / timeTaken;
        wpm *= 60;
        float decreaser = 2.5f;
        float damageDelt = wpm / decreaser;

        print("Damage delt " + damageDelt);
        return damageDelt;
    }
}
