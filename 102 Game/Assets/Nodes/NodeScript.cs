using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class NodeScript : MonoBehaviour
{
    public List<Action> choices;

    public Sprite nodeImage;

    //public Battler battler;

    public string sceneText;

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
