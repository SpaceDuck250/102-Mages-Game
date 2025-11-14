using UnityEngine;

public class CommonCommandsScript : MonoBehaviour
{

    // yes I could have made each their own action script but.... 
    public bool CheckCommonCommands(string command, NodeScript currentNode)
    {

        if (command == "next")
        {
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

        return false;
    }

    public void OutputInvalidCommandText()
    {
        string invalidText = "Invalid command, type \"open help\" or press i icon to see what commands you can execute...";
        DialogueManager.instance.PlayLine(invalidText);
    }
}
