using UnityEngine;
using System.Collections.Generic;
using System;

public class NodeScript : MonoBehaviour
{
    public List<Action> choices;

    public Sprite nodeImage;

    [TextArea(2, 10)]
    public List<string> nodeTexts = new List<string>();

    bool initializedActions = false;
    public bool dontDisplayDialogueLines = false;
    public bool endlessTypeOfNode = false;

    // make sure the player has seen all the lines of dialogue before stopping it
    public bool seenAllLinesOfDialogue = false;

    public void SetNodeToCurrentNode()
    {
        GetAllActionsFromChildren();

        CommandProcessor commandProcessor = CommandProcessor.instance;
        commandProcessor.currentNode = this;
        commandProcessor.onNewNodeEnter?.Invoke(this);
    }

    public bool CheckIfEnteredChoicesAndExecute(string input)
    {
        foreach (Action choice in choices)
        {
            if (choice.CheckCommand(input))
            {
                choice.DoAction();
                choice.SaySomething();

                return true;
                
            }
        }

        return false;
    }

    public void LeaveNode()
    {
        NodeDialogueSender nodeDialogueSender = GameManager.instance.nodeDialogueSender;
        nodeDialogueSender.LeaveCurrentNode();

        if (endlessTypeOfNode || !seenAllLinesOfDialogue)
        {
            return;
        }

        dontDisplayDialogueLines = true;
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
