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
        currentNode.SetNodeToCurrentNode();
    }

    public void EnterCommand(string command)
    {
        string cleanedUpCommand = command.Trim().ToLower();

        if (battleMode)
        {
            wordGiver.CheckIfCommandMatchesWord(cleanedUpCommand);
            return;
        }

        CheckCommonCommands(cleanedUpCommand);
        currentNode.CheckChoices(cleanedUpCommand);
    }

    public void CheckCommonCommands(string command)
    {
        if (command == "next")
        {
            DialogueManager.instance.PlayLine(currentNode.sceneText);
        }
    }



}
