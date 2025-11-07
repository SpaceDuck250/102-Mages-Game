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

    private void Awake()
    {
        instance = this;
        UImanager = GameManager.instance.uiManager;
        player = GameManager.instance.player;
        wordGiver = GameManager.instance.wordGiver;
    }

    public void CommenceBattle(Battler newBattler)
    {
        currentBattler = newBattler;
        RevivePlayerAndBattler();

        isPlayersTurn = true;
        UImanager.SetupBattlePanel();

        GivePlayerWordToType(); // This will start the cycle back and forth between the player and the battler
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
        EndBattle();
    }

    public void OnPlayerDeath()
    {
        EndBattle();
        print("player Died");
    }

    public IEnumerator LetBattlerAttack() // Then check if the player died
    {
        float waitTime = 1;
        yield return new WaitForSeconds(waitTime);

        float damageDelt = currentBattler.PickDamageValue();  
        DealDamageTo(damageDelt, player.gameObject);

        CheckWhosTurnAndSwitch();
    }

    public void LetPlayerAttack(float timeTaken, int wordCount)
    {
        float damageDelt = CalculatePlayerDamage(timeTaken, wordCount);
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

    public void GivePlayerWordToType() // Then check if the battler died
    {
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
            GivePlayerWordToType();
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
