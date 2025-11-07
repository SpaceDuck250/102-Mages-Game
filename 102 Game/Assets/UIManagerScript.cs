using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] HealthBarScript playerHealthBar;
    [SerializeField] HealthBarScript battlerHealthBar;

    [SerializeField] GameObject battlePanel;

    [SerializeField] TextMeshProUGUI promptTextBox;

    PlayerScript player;
    BattleManager battleManager;

    private void Start()
    {
        player = GameManager.instance.player;
        battleManager = GameManager.instance.battleManager;
    }

    public void SetupBattlePanel()
    {
        battlePanel.SetActive(true);

        playerHealthBar.InitializeSlider("Player Health");

        string battlerName = BattleManager.instance.currentBattler.battlerName;
        battlerHealthBar.InitializeSlider(battlerName + " Health");
    }

    public void CloseBattlePanel()
    {
        battlePanel.SetActive(false);
    }

    public void UpdateBothHealthBars()
    {
        SendHealthToHealthBar(player.gameObject, playerHealthBar);
        SendHealthToHealthBar(battleManager.currentBattler.gameObject, battlerHealthBar);
    }

    public void SendHealthToHealthBar(GameObject obj, HealthBarScript healthBar)
    {
        HealthScript HealthComponent = obj.GetComponent<HealthScript>();
        if (HealthComponent != null)
        {
            float health = HealthComponent.health;
            float maxHealth = HealthComponent.maxHealth;
            healthBar.OnHealthChanged(health, maxHealth);
        }
    }

    public void SetPromptTextTo(string promptText)
    {
        promptTextBox.text = promptText;
    }
}
