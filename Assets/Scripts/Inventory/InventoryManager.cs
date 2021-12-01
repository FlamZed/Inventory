using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Item> inventoryList; // Список Item в инвентаре
    public event Action OnChangeCountItem; // Ивент о изменении кол-во Item
    public static InventoryManager Instance => instance;
    private static InventoryManager instance;

    private void Start()
    {
        instance = this;
    }

    public void InventoryListAdd(Item item)
    {
        inventoryList.Add(item);

        if (OnChangeCountItem != null) 
            OnChangeCountItem();
    }

    public void InventoryListRemove(Item item)
    {
        inventoryList.Remove(item);

        if (OnChangeCountItem != null) 
            OnChangeCountItem();
    }

    public List<Item> GetItems()
    {
        return inventoryList;
    }

    public Item InventoryListGetItem(int indexItem)
    {
        return inventoryList[indexItem];
    }

    public int InventoryListCount()
    {
        return inventoryList.Count;
    }
}