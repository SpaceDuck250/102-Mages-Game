using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] HealthBarScript playerHealthBar;
    [SerializeField] HealthBarScript battlerHealthBar;
    public Image battlerImageComponent;
    public Image fightSceneImageComponent;
    public Image playerImageComponent;
    [SerializeField] GameObject battlePanel;
    [SerializeField] TextMeshProUGUI promptTextBox;

    PlayerScript player;
    BattleManager battleManager;

    public Image currentNodeImageComponent;
    public TMP_InputField inputField;

    public TextMeshProUGUI dialoguePageCounter;

    public HelpPanelScript helpPanelScript;

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

        Sprite battlerImage = battleManager.currentBattler.battlerImage;
        Sprite fightSceneImage = battleManager.currentBattler.fightSceneImage;
        if (battlerImage != null && fightSceneImage != null)
        {
            battlerImageComponent.sprite = battlerImage;
            fightSceneImageComponent.sprite = fightSceneImage;
        }

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

    public void ClearLineWhenEndEnter()
    {
        inputField.text = "";
        inputField.ActivateInputField();
    }

    public void UpdateCurrentNodeImage(Sprite newImage)
    {
        currentNodeImageComponent.sprite = newImage;
    }

    public void CloseDialoguePageCounter()
    {
        dialoguePageCounter.gameObject.SetActive(false);
    }

    public void SetDialoguePageCounter(int currentIndex, int maxIndex)
    {
        dialoguePageCounter.gameObject.SetActive(true);

        int correctedIndex = currentIndex + 1;
        string pageCounterText = $"{correctedIndex} / {maxIndex}";
        dialoguePageCounter.text = pageCounterText;
    }

    public void OpenInventory()
    {
        helpPanelScript.gameObject.SetActive(false);
    }

}
