using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using JetBrains.Annotations;

public class InventoryUIBuilder : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform container;
    public float xSeparation;
    public float ySeparation;

    public int indexXMax;

    public void CreateAllItemsUIFromInventory(Dictionary<Items, int> inventoryItems)
    {
        ClearAllItems();

        int xIndex = 0;
        int yIndex = 0;

        foreach (var item in inventoryItems)
        {
            Items actualItem = item.Key;
            int itemAmount = item.Value;

            CreateItemUI(actualItem, itemAmount, xIndex, yIndex);

            IncrementIndexes(ref xIndex, ref yIndex);

            print(xIndex + " " + yIndex);

        }

    }


    void CreateItemUI(Items item, int amount, int positionIndexX, int positionIndexY)
    {
        GameObject newItem = Instantiate(itemPrefab, itemPrefab.transform.position, Quaternion.identity, container);

        RectTransform newItemRect = newItem.GetComponent<RectTransform>();
        newItemRect.position += new Vector3(positionIndexX, 0, 0) * xSeparation;
        newItemRect.position += new Vector3(0, -positionIndexY, 0) * ySeparation;

        Image newItemImageComponent = newItem.GetComponent<Image>();
        newItemImageComponent.sprite = item.itemSprite;

        TextMeshProUGUI amountText = newItem.transform.Find("AmountText").GetComponent<TextMeshProUGUI>();
        amountText.text = amount + "x";

        newItem.SetActive(true);
    }

    void ClearAllItems()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }

    void IncrementIndexes(ref int xIndex, ref int yIndex)
    {
        xIndex += 1;
        if (xIndex > indexXMax)
        {
            xIndex = 0;
            yIndex += 1;
        }
    }
}
