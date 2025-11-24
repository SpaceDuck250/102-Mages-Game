using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DataConverter : MonoBehaviour
{

    public Dictionary<string, NodeScript> nodesDict = new Dictionary<string, NodeScript>();
    public Dictionary<string, Items> itemDict = new Dictionary<string, Items>();

    public List<Items> itemList = new List<Items>();

    public Transform nodeContainer;

    private void Start()
    {
        GrabAllNodeComponentsFromChildren(nodeContainer);
        AddAllGameItemsToDict(itemList);
    }

    public T ConvertStringToDictionaryItem<T>(string searchString, Dictionary<string, T> searchDictionary)
    {
        if (searchDictionary.ContainsKey(searchString))
        {
            return searchDictionary[searchString];
        }

        return default(T);
    }

    public string ConvertDictionaryItemToString<T>(T searchItem, Dictionary<string, T> searchDictionary)
    {
        var matchedValue = searchDictionary.Where(n => EqualityComparer<T>.Default.Equals(n.Value, searchItem)).FirstOrDefault();
        string convertedString = matchedValue.Key;

        return convertedString;
    }

    private void GrabAllNodeComponentsFromChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            NodeScript nodeComponent = child.gameObject.GetComponent<NodeScript>();
            string nameInDict = child.gameObject.name;

            nodesDict.Add(nameInDict, nodeComponent);
        }
    }

    private void AddAllGameItemsToDict(List<Items> itemsList)
    {
        foreach (Items item in itemsList)
        {
            string itemName = item.itemName;

            itemDict.Add(itemName, item);
        }
    }

}
