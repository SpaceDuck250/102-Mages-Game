using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonCommandsScript : MonoBehaviour
{

    // yes I could have made each their own action script but.... 
    // clean this up later
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

            HelpPanelScript helpPanelScript = GameManager.instance.uiManager.helpPanelScript;
            helpPanelScript.UpdateHelpPanel();

            return true;
        }
        else if (command == "open help")
        {
            HelpPanelScript helpPanelScript = GameManager.instance.uiManager.helpPanelScript;
            helpPanelScript.OpenHelpPanel();

            return true;
        }
        else if (command == "") // To fix the bug of the player deselecting the inputfield and it being registered as an invalid command
        {
            return true;
        }
        else if (command == "open inv")
        {
            HelpPanelScript helpPanelScript = GameManager.instance.uiManager.helpPanelScript;
            helpPanelScript.CloseHelpPanel();

            return true;

        }
        else if (command == "go to main menu")
        {
            SceneManager.LoadScene("MainMenu");

            return true;
        }
        else if (command == "save game")
        {
            DataSaver dataSaver = GameManager.instance.dataSaver;
            dataSaver.SaveGame();
            return true;
        }
        else if (command == "load game")
        {
            DataSaver dataSaver = GameManager.instance.dataSaver;
            dataSaver.LoadGame();
            return true;
        }
        else if (command == "new game")
        {
            DataSaver dataSaver = GameManager.instance.dataSaver;
            dataSaver.ClearData();
            SceneManager.LoadScene("MainMenu");
            return true;


        }

        return false;

    }

    public void OutputInvalidCommandText()
    {
        string invalidText = "Invalid command, type \"open help\" to see what commands you can execute...";
        DialogueManager.instance.PlayLine(invalidText);

        PageCounterScript pageCounterScript = GameManager.instance.uiManager.pageCounterScript;
        pageCounterScript.CloseDialoguePageCounter();

    }
}
