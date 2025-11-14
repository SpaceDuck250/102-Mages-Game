using UnityEngine;

public class NodeDialogueSender : MonoBehaviour
{
    NodeScript selectedNode;
    int dialogueIndexCounter;

    UIManager uiManager;

    private void Start()
    {
        uiManager = GameManager.instance.uiManager;
    }

    public string SendDialogueLineAndIncrement(NodeScript node)
    {
        //if (node.dontDisplayDialogueLines)
        //{
        //    return "";
        //}

        // If we come back to the same node increment, else set counter to 0
        CheckIfReturnedToSameNode(node);

        string textOutput = node.nodeTexts[dialogueIndexCounter];
        return textOutput;
    }

    void CheckIfReturnedToSameNode(NodeScript node)
    {
        if (selectedNode != null && selectedNode == node)
        {
            TryIncrementing(selectedNode);
        }
        else
        {
            selectedNode = node;
            dialogueIndexCounter = 0;
        }

        int maxIndex = node.nodeTexts.Count;
        uiManager.SetDialoguePageCounter(dialogueIndexCounter, maxIndex);
    }

    void TryIncrementing(NodeScript node)
    {
        dialogueIndexCounter++;

        CheckIfAllLinesOfDialogueAreRead(node);

        if (dialogueIndexCounter == node.nodeTexts.Count)
        {
            dialogueIndexCounter = 0;
        }
    }

    void CheckIfAllLinesOfDialogueAreRead(NodeScript node)
    {
        if (dialogueIndexCounter == node.nodeTexts.Count - 1)
        {
            node.seenAllLinesOfDialogue = true;
        }
    }

    public void LeaveCurrentNode()
    {
        selectedNode = null;
    }
}
