using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<Items, int> inventoryItems = new Dictionary<Items, int>();
    public InventoryUIBuilder inventoryUIBuilder;

    public List<Items> testItems = new List<Items>();
    private void Start()
    {
        foreach (Items item in testItems)
        {
            AddItemToInventory(item, 2);
        }
    }

    public void AddItemToInventory(Items item, int amount)
    {
        if (inventoryItems.ContainsKey(item))
        {
            inventoryItems[item] += amount;
        }
        else
        {
            inventoryItems[item] = amount;
        }

        int amountLeft = inventoryItems[item];
        CheckIfNoneLeftAndDestroy(amountLeft, item);

        inventoryUIBuilder.CreateAllItemsUIFromInventory(inventoryItems);
    }

    void CheckIfNoneLeftAndDestroy(int amount, Items item)
    {
        if (amount <= 0)
        {
            inventoryItems.Remove(item);
        }
    }


}
