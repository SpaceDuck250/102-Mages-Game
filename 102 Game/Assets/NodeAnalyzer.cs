using UnityEngine;
using UnityEngine.UI;

public class CommandProcessor : MonoBehaviour
{
    public static CommandProcessor instance;
    public Image imageDisplay;

    private void Awake()
    {
        instance = this;
    }

    public NodeScript currentNode;

    public bool battleMode = false;

    public void EnterCommand(string command)
    {
        if (battleMode)
        {
            currentNode.battler.StartBattle();
            return;
        }

        if (command.ToLower() == "next" || command.ToLower() == "start")
        {
            DialogueManager.instance.PlayLine(currentNode.sceneText);
            return;
        }

        currentNode.CheckChoices(command);
        imageDisplay.sprite = currentNode.nodeImage;
    }

    private void Start()
    {
        imageDisplay.sprite = currentNode.nodeImage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DialogueManager.instance.FinishLine();
        }
    }

}
