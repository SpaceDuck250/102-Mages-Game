using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public string currentNode;
    public Dictionary<string, int> itemsHeld = new Dictionary<string, int>();

    public GameData(string currentNode, Dictionary<string, int> items)
    {
        this.currentNode = currentNode;
        itemsHeld = items;
    }
}
