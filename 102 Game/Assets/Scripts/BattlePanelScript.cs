using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanelScript : MonoBehaviour
{
    public HealthBarScript playerHealthBar;
    public HealthBarScript battlerHealthBar;
    public Image battlerImageComponent;
    public Image fightSceneImageComponent;
    public Image playerImageComponent;

    public TextMeshProUGUI promptTextBox;

    public GameObject battlePanel;

    BattleManager battleManager;

    private void Start()
    {
        battleManager = GameManager.instance.battleManager;
        battleManager.onBattleStart += SetupBattlePanel;
        battleManager.onBattleEnd += CloseBattlePanel;

    }

    private void OnDestroy()
    {
        battleManager.onBattleStart -= SetupBattlePanel;
        battleManager.onBattleEnd -= CloseBattlePanel;

    }

    private void SetupBattlePanel(Battler currentBattler)
    {
        battlePanel.SetActive(true);

        playerHealthBar.InitializeSlider("Player Health");

        string battlerName = currentBattler.battlerName;
        battlerHealthBar.InitializeSlider(battlerName + " Health");

        Sprite battlerImage = currentBattler.battlerImage;
        Sprite fightSceneImage = currentBattler.fightSceneImage;
        if (battlerImage != null && fightSceneImage != null)
        {
            battlerImageComponent.sprite = battlerImage;
            fightSceneImageComponent.sprite = fightSceneImage;
        }
    }

    public void SetPromptTextTo(string promptText)
    {
        promptTextBox.text = promptText;
    }

    public void CloseBattlePanel(Battler currentBattler)
    {
        battlePanel.SetActive(false);
    }
}
