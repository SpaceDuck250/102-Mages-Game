using System;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    public static CommandProcessor instance;
    CommonCommandsScript commonCommands;

    public NodeScript currentNode;
    public Action<NodeScript> onNewNodeEnter;

    public event Action<string> onBattleCommandEntered;

    public bool battleMode = false;


    private void Awake()
    {
        instance = this;
        commonCommands = GetComponent<CommonCommandsScript>();
    }

    private void Start()
    {
        currentNode.SetNodeToCurrentNode();
    }


    public void EnterCommand(string command)
    {
        string cleanedUpCommand = command.Trim().ToLower();

        if (battleMode)
        {
            onBattleCommandEntered?.Invoke(cleanedUpCommand);

            return;
        }

        TryToExecuteCommand(cleanedUpCommand);

    }

    void TryToExecuteCommand(string command)
    {
        bool isValidCommand = currentNode.CheckIfEnteredChoicesAndExecute(command) || commonCommands.CheckCommonCommands(command, currentNode);

        if (!isValidCommand)
        {
            commonCommands.OutputInvalidCommandText();
        }
    }





}
