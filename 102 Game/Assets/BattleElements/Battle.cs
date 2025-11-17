using UnityEngine;

public class Battle : Action
{
    CommandProcessor cprocessor;
    BattleManager bmanager;

    [SerializeField] Battler heldBattler;
    string battlerName;

    public NodeScript winNode;
    public NodeScript lostNode;

    private void Start()
    {
        cprocessor = CommandProcessor.instance;
        bmanager = BattleManager.instance;

        battlerName = heldBattler.battlerName;
        commandInput = $"fight {battlerName}";
    }

    public override void DoAction()
    {
        HealthScript battlerHealthComponent = heldBattler.gameObject.GetComponent<HealthScript>();
        if (battlerHealthComponent.dead)
        {
            return;
        }


        cprocessor.battleMode = true;
        bmanager.CommenceBattle(heldBattler);

        //heldBattler.SetupAfterBattleNode(cprocessor.currentNode);
        //NodeScript newNode = heldBattler.gameObject.transform.Find("AfterBattleNode").GetComponent<NodeScript>();
        //newNode.SetNodeToCurrentNode();
    }
}
