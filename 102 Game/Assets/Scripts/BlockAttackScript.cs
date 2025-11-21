using UnityEngine;
using System.Collections;
using System;

public class BlockAttackScript : MonoBehaviour
{
    public string blockCommand;

    [SerializeField]
    private bool blocked;

    public float blockTime;

    public event Action<float> onBlock;
    public event System.Action onUnblock;

    CommandProcessor commandProcessor;

    private void Start()
    {
        commandProcessor = CommandProcessor.instance;
        commandProcessor.onBattleCommandEntered += CheckIfEnteredBlockCommand;

        blockCommand = blockCommand.Trim().ToLower();
    }

    private void OnDestroy()
    {
        commandProcessor.onBattleCommandEntered -= CheckIfEnteredBlockCommand;
    }

    public void CheckIfEnteredBlockCommand(string command)
    {
        if (command == blockCommand && !blocked)
        {
            StartCoroutine(ExecuteBlock());
        }
    }

    private IEnumerator ExecuteBlock()
    {
        blocked = true;
        onBlock?.Invoke(blockTime);
        print("Block");

        yield return new WaitForSeconds(blockTime);

        blocked = false;
        onUnblock?.Invoke();
        print("Un-Block");


    }
}
