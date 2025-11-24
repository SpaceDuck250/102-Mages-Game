using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private DataSaver dataSaver;
    private DataConverter dataConverter;

    public PlayerInventory playerInventory;
    public InventoryUIBuilder inventoryUIBuilder;

    public string initialGameLine;

    private void Start()
    {
        DialogueManager.instance.PlayLine(initialGameLine);

        dataSaver = GameManager.instance.dataSaver;
        dataConverter = GameManager.instance.dataConverter;

        dataSaver.onGameDataLoaded += OnGameDataLoaded;
    }

    private void OnDestroy()
    {
        dataSaver.onGameDataLoaded -= OnGameDataLoaded;

    }

    private void OnGameDataLoaded(GameData gameData)
    {
        LoadNode(gameData);
        LoadInventory(gameData);
    }

    private void LoadNode(GameData gameData)
    {
        string loadedNodeString = gameData.currentNode;
        NodeScript loadedNode = dataConverter.ConvertStringToDictionaryItem<NodeScript>(loadedNodeString, dataConverter.nodesDict);

        loadedNode.SetNodeToCurrentNode();
    }

    private void LoadInventory(GameData gameData)
    {
        Dictionary<Items, int> inventoryItems = new Dictionary<Items, int>();

        Dictionary<string, int> inventoryStringItems = gameData.itemsHeld;
        foreach (var item in inventoryStringItems)
        {
            string itemString = item.Key;
            int itemAmount = item.Value;

            Items itemComponent = dataConverter.ConvertStringToDictionaryItem<Items>(itemString, dataConverter.itemDict);

            inventoryItems.Add(itemComponent, itemAmount);

        }

        inventoryUIBuilder.CreateAllItemsUIFromInventory(inventoryItems);
    }

}
