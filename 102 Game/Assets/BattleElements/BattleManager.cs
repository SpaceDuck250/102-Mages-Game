using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    UIManager UImanager;
    public PlayerScript player;
    WordGiver wordGiver;

    public Battler currentBattler;

    public bool isPlayersTurn;

    public Animator battlerAnimator;
    public Animator playerAnimator;

    private void Awake()
    {
        instance = this;
        UImanager = GameManager.instance.uiManager;
        player = GameManager.instance.player;
        wordGiver = GameManager.instance.wordGiver;
    }

    private void Start()
    {
        playerAnimator = UImanager.playerImageComponent.GetComponent<Animator>();
        battlerAnimator = UImanager.battlerImageComponent.GetComponent<Animator>();
    }

    public void CommenceBattle(Battler newBattler)
    {
        currentBattler = newBattler;
        RevivePlayerAndBattler();

        isPlayersTurn = true;
        UImanager.SetupBattlePanel();

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
        UImanager.CloseBattlePanel();
        print("Finished");
    }

    public void OnBattlerDeath()
    {
        DialogueManager.instance.PlayLine("You have won the battle against " + currentBattler.battlerName);

        EndBattle();
    }

    public void OnPlayerDeath()
    {
        DialogueManager.instance.PlayLine("You have lost the battle to " + currentBattler.battlerName);

        EndBattle();
    }

    public IEnumerator LetBattlerAttack() // Then check if the player died
    {
        float waitTime = 1.2f;
        yield return new WaitForSeconds(waitTime);
        PlayAnim(battlerAnimator, "Base Layer.battlerattack");


        float damageDelt = currentBattler.PickDamageValue();  
        DealDamageTo(damageDelt, player.gameObject);

        CheckWhosTurnAndSwitch();
    }

    public void LetPlayerAttack(float timeTaken, int wordCount)
    {
        float damageDelt = CalculatePlayerDamage(timeTaken, wordCount);
        PlayAnim(playerAnimator, "Base Layer.playerattack");
        DealDamageTo(damageDelt, currentBattler.gameObject);

        CheckWhosTurnAndSwitch();
    }

    void DealDamageTo(float damage, GameObject obj)
    {
        HealthScript healthComponent = obj.GetComponent<HealthScript>();
        healthComponent.TakeDamage(damage);
        UImanager.UpdateBothHealthBars();

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

    void PlayAnim(Animator animator, string animationName)
    {
        animator.Play(animationName, 0, 0);
    }


}
