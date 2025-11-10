using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    Dictionary<Items, int> inventoryItems = new Dictionary<Items, int>();

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

        // inventory ui builder

        print("looted");
    }


}
