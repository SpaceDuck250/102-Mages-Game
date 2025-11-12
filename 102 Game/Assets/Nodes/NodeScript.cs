using UnityEngine;
using System.Collections.Generic;

public class NodeScript : MonoBehaviour
{
    public List<Action> choices;

    public Sprite nodeImage;

    public List<string> nodeTexts = new List<string>();

    bool initializedActions = false;
    public bool visitedAlready = false;
    public bool endlessTypeOfNode = false;

    public void SetNodeToCurrentNode()
    {
        GetAllActionsFromChildren();

        CommandProcessor.instance.currentNode = this;

        UIManager uiManager = GameManager.instance.uiManager;
        uiManager.UpdateCurrentNodeImage(nodeImage);
    }

    public void CheckChoices(string input)
    {
        foreach (Action choice in choices)
        {
            if (choice.CheckCommand(input))
            {
                choice.DoAction();
                choice.SaySomething();
                
            }
        }
    }

    public void LeaveNode()
    {
        if (endlessTypeOfNode)
        {
            return;
        }

        visitedAlready = true;
        nodeTexts.Clear();
    }

    void GetAllActionsFromChildren()
    {
        if (initializedActions)
        {
            return;
        }

        choices.Clear();

        foreach (Transform child in transform)
        {
            Action possibleAction = child.gameObject.GetComponent<Action>();
            choices.Add(possibleAction);
        }
        initializedActions = true;
    }
}
