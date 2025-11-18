using UnityEngine;

public class LootAction : Action
{
    public Items lootableItem;
    public int amount;
    bool looted = false;

    PlayerInventory inventory;

    private void Start()
    {
        inventory = GameManager.instance.player.GetComponent<PlayerInventory>();
        SetupCommand();
    }

    public override void DoAction()
    {
        if (looted)
        {
            outputLine = $"There were no {lootableItem.name}s to loot";
            return;
        }

        inventory.AddItemToInventory(lootableItem, amount);
        looted = true;
    }

    void SetupCommand()
    {
        commandInput = $"loot {lootableItem.itemName}";
        outputLine = $"You looted {lootableItem.itemName} {amount}x";
    }

}
