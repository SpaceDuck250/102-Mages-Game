using UnityEngine;

public class NodeAnalyzer : MonoBehaviour
{
    public NodeScript currentNode;

    public void EnterCommand(string command)
    {
        currentNode.CheckChoices(command);
    }

}
