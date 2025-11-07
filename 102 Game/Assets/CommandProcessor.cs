using UnityEngine;
using UnityEngine.UI;

public class CommandProcessor : MonoBehaviour
{
    public static CommandProcessor instance;
    WordGiver wordGiver;
    public Image imageDisplay;

    public NodeScript currentNode;

    public bool battleMode = false;

    private void Awake()
    {
        instance = this;
        wordGiver = GameManager.instance.wordGiver;

    }

    private void Start()
    {
        imageDisplay.sprite = currentNode.nodeImage;
    }

    public void EnterCommand(string command)
    {
        if (battleMode)
        {
            wordGiver.CheckIfCommandMatchesWord(command);
            //BattleManager.instance.CommenceBattle(currentNode.battler);
            return;
        }

        CheckCommonCommands(command);
        currentNode.CheckChoices(command);

        imageDisplay.sprite = currentNode.nodeImage;
    }

    public void CheckCommonCommands(string command)
    {
        if (command.ToLower() == "next" && DialogueManager.instance.currentLine != "")
        {
            DialogueManager.instance.PlayLine(currentNode.sceneText);
            

        }
        else if (command.ToLower() == "start" && DialogueManager.instance.currentLine == "")
        {
            DialogueManager.instance.PlayLine(currentNode.sceneText);
        }
    }



}
