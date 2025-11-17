using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

    public void CloseBattlePanel()
    {
        battlePanel.SetActive(false);
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
