using UnityEngine;

public class GiveAction : Action
{
    public Items itemToTrade;
    public int tradeAmount;

    bool traded = false;

    public override void DoAction()
    {
        if (traded)
        {
            string alreadyGivenText = $"You already gave away {itemToTrade.itemName} and receiver doesn't want anymore";
            outputLine = alreadyGivenText;
            return;
        }

        PlayerInventory inventoryScript = GameManager.instance.player.GetComponent<PlayerInventory>();
 
        if (inventoryScript.inventoryItems.ContainsKey(itemToTrade))
        {
            inventoryScript.AddItemToInventory(itemToTrade, -tradeAmount);
            traded = true;
        }
    }
}
