using UnityEngine;

public class LootAction : Action
{
    public Items lootableItem;
    public int amount;

    PlayerInventory inventory;

    private void Start()
    {
        inventory = GameManager.instance.player.GetComponent<PlayerInventory>();
        SetupCommand();
    }

    public override void DoAction()
    {
        inventory.AddItemToInventory(lootableItem, amount);
    }

    void SetupCommand()
    {
        commandInput = "loot " + lootableItem.name;
        outputLine = "You looted " + lootableItem.name + " " + amount + "x";
    }

}
