using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HelpPanelScript : MonoBehaviour
{
    public GameObject helpPanel;
    public TextMeshProUGUI possibleActionsText;

    public CommandProcessor commandProcessor;

    public bool opened = false;

    public void UpdateHelpPanel()
    {
        List<Action> possibleActionsList = commandProcessor.currentNode.choices;
        string outputText = MakeActionText(possibleActionsList);

        possibleActionsText.text = outputText;
    }

    public void OpenCloseHelpPanel()
    {
        if (opened)
        {
            CloseHelpPanel();
        }
        else
        {
            OpenHelpPanel();
        }

    }

    public void CloseHelpPanel()
    {
        opened = false;
        helpPanel.SetActive(false);
    }

    public void OpenHelpPanel()
    {
        opened = true;
        UpdateHelpPanel();
        helpPanel.SetActive(true);
    }

    string MakeActionText(List<Action> possibleActions)
    {
        string outputText = "";

        bool readAllLines = commandProcessor.currentNode.seenAllLinesOfDialogue;
        if (readAllLines)
        {
            outputText += AddActionsText(possibleActions);
        }

        outputText += AddCommonCommandsText();

        return outputText;
    }

    string AddCommonCommandsText()
    {
        string commonCommandsText = "";

        NodeScript node = commandProcessor.currentNode;
        if (!node.dontDisplayDialogueLines)
        {
            commonCommandsText = string.Concat(commonCommandsText, "next \n");
        }

        commonCommandsText = string.Concat(commonCommandsText, "open inv");

        return commonCommandsText;
    }

    string AddActionsText(List<Action> possibleActions)
    {
        string actionsText = "";

        foreach (Action action in possibleActions)
        {
            string actionCommandInput = action.commandInput;
            actionCommandInput = actionCommandInput.ToLower();

            actionsText = string.Concat(actionsText, $"{actionCommandInput} \n");
        }

        return actionsText;

    }


}
