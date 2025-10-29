using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public string commandInput;
    public string outputLine;
    public NodeScript transitionNode;

    public abstract void DoAction();

    public virtual bool CheckCommand(string input)
    {
        if (input.ToLower() == commandInput.ToLower())
        {
            return true;
        }

        return false;
    }

    public virtual void SaySomething()
    {
        DialogueManager.instance.PlayLine(outputLine);
    }
}
