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
        if (node.visitedAlready)
        {
            return "";
        }

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
        if (dialogueIndexCounter == node.nodeTexts.Count)
        {
            dialogueIndexCounter = 0;
        }
    }
}
