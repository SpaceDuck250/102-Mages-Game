using UnityEngine;

public class HealthBarUIScript : MonoBehaviour
{
    public GameObject player;

    public HealthBarScript playerHealthBar;
    public HealthBarScript battlerHealthBar;

    BattleManager battleManager;

    private void Start()
    {
        battleManager = GameManager.instance.battleManager;
        battleManager.onPlayerAttack += UpdateBothHealthBars;
        battleManager.onEnemyAttack += UpdateBothHealthBars;
        print("subbed");
    }

    private void OnDestroy()
    {
        battleManager.onPlayerAttack -= UpdateBothHealthBars;
        battleManager.onEnemyAttack -= UpdateBothHealthBars;
    }

    private void UpdateBothHealthBars(float damage, Battler currentBattler)
    {
        SendHealthToHealthBar(player.gameObject, playerHealthBar);

        if (currentBattler != null)
        {
            SendHealthToHealthBar(currentBattler.gameObject, battlerHealthBar);

        }
    }


    public void SendHealthToHealthBar(GameObject obj, HealthBarScript healthBar)
    {
        if (obj == null)
        {
            return;
        }

        HealthScript HealthComponent = obj.GetComponent<HealthScript>();
        if (HealthComponent != null)
        {
            float health = HealthComponent.health;
            float maxHealth = HealthComponent.maxHealth;
            healthBar.OnHealthChanged(health, maxHealth);
        }
    }
}
