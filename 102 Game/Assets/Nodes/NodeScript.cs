using UnityEngine;
using System.Collections.Generic;

public class NodeScript : MonoBehaviour
{
    public List<Action> choices;

    public Sprite nodeImage;

    public string sceneText;

    public void SetNodeToCurrentNode()
    {
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
}
