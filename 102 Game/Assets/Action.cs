using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public string commandInput;

    public abstract void DoAction();

    public virtual bool CheckCommand(string input)
    {
        if (input.ToLower() == commandInput.ToLower())
        {
            return true;
        }

        return false;
    }
}
