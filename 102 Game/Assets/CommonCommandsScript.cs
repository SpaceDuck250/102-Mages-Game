using UnityEngine;

public class CommonCommandsScript : MonoBehaviour
{

    // yes I could have made each their own action script but.... 
    public bool CheckCommonCommands(string command, NodeScript currentNode)
    {

        if (command == "next")
        {
            if (currentNode.dontDisplayDialogueLines)
            {
                return false;
            }

            NodeDialogueSender nodeDialogueSender = GameManager.instance.nodeDialogueSender;
            string dialogueLine = nodeDialogueSender.SendDialogueLineAndIncrement(currentNode);
            DialogueManager.instance.PlayLine(dialogueLine);

            return true;
        }
        else if (command == "open help")
        {
            HelpPanelScript helpPanelScript = GameManager.instance.uiManager.helpPanelScript;
            helpPanelScript.OpenHelpPanel();

            return true;
        }
        else if (command == "close help")
        {
            HelpPanelScript helpPanelScript = GameManager.instance.uiManager.helpPanelScript;
            helpPanelScript.CloseHelpPanel();

            return true;
        }
        else if (command == "") // To fix the bug of the player deselecting the inputfield and it being registered as an invalid command
        {
            return true;
        }

        return false;
    }

    public void OutputInvalidCommandText()
    {
        string invalidText = "Invalid command, type \"open help\" to see what commands you can execute...";
        DialogueManager.instance.PlayLine(invalidText);

        UIManager uiManager = GameManager.instance.uiManager;
        uiManager.CloseDialoguePageCounter();

    }
}
