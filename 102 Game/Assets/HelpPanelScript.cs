using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HelpPanelScript : MonoBehaviour
{
    public GameObject helpPanel;
    public TextMeshProUGUI possibleActionsText;

    public CommandProcessor commandProcessor;

    public bool opened = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UpdateHelpPanel();
        }
    }

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
        foreach (Action action in possibleActions)
        {
            string actionCommandInput = action.commandInput;
            actionCommandInput = actionCommandInput.ToLower();

            outputText = string.Concat(outputText, $"{actionCommandInput} \n");
        }

        return outputText;
    }

}
