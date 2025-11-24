using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class DataSaver : MonoBehaviour
{
    public DataConverter gameDataConverter;

    public event Action<GameData> onGameDataLoaded;

    public CommandProcessor commandProcessor;
    public PlayerInventory playerInventoryScript;

    private void Start()
    {
        commandProcessor = CommandProcessor.instance;
    }

    public GameData CreateSaveFile(NodeScript currentNode, Dictionary<Items, int> inventoryItems)
    {
        string currentNodeString = gameDataConverter.ConvertDictionaryItemToString<NodeScript>(currentNode, gameDataConverter.nodesDict);

        Dictionary<string, int> inventoryItemsDict = new Dictionary<string, int>();
        foreach (var item in inventoryItems)
        {
            Items itemComponent = item.Key;
            int itemCount = item.Value;

            string itemComponentString = gameDataConverter.ConvertDictionaryItemToString<Items>(itemComponent, gameDataConverter.itemDict);

            inventoryItemsDict.Add(itemComponentString, itemCount);
        }

        GameData newSaveFile = new GameData(currentNodeString, inventoryItemsDict);
        return newSaveFile;
    }

    public void SaveData(GameData gameData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/smt.anything";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        bf.Serialize(fileStream, gameData);

        fileStream.Close();

        print("saved");
    }

    public GameData LoadData()
    {
        string path = Application.persistentDataPath + "/smt.anything";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            GameData loadedGameData = (GameData)bf.Deserialize(fileStream);

            fileStream.Close();
            print("load");

            return loadedGameData;
        }
        else
        {
            return null;
        }
    }

    public void ClearData()
    {
        string path = Application.persistentDataPath + "/smt.anything";
        File.Delete(path);
    }

    public void SaveGame()
    {
        NodeScript currentNode = commandProcessor.currentNode;
        Dictionary<Items, int> inventoryItems = playerInventoryScript.inventoryItems;

        GameData newGameData = CreateSaveFile(currentNode, inventoryItems);

        SaveData(newGameData);
    }

    public void LoadGame()
    {
        GameData loadedGameData = LoadData();
        if (loadedGameData == null)
        {
            return;
        }
        onGameDataLoaded?.Invoke(loadedGameData);
    }
}


