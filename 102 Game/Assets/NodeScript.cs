using UnityEngine;
using System.Collections.Generic;

public class NodeScript : MonoBehaviour
{

    public List<Action> choices;

    public string inputString;

    private void Update()
    {
        if (choices[0].CheckCommand(inputString))
        {
            choices[0].DoAction();
        }
    }
}
