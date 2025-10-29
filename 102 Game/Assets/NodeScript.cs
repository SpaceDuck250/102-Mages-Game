using UnityEngine;
using System.Collections.Generic;

public class NodeScript : MonoBehaviour
{

    public List<Action> choices;

    public string inputString;

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
}
