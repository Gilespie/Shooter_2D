using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    [SerializeField] private List<InventoryItem> _inventoryItems;
    [field: SerializeField] public int Size { get; private set; } = 10;

    public void Initialize()
    {
        _inventoryItems = new List<InventoryItem>();

        for(int i = 0; i  < Size; i++)
        {
            _inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    }

    public void AddItem(ItemSO item, int quantity)
    {
        for (int i = 0; i < _inventoryItems.Count; i++)
        {
            if (_inventoryItems[i].IsEmpty)
            {
                _inventoryItems[i] = new InventoryItem
                {
                    item = item,
                    quantity = quantity
                };
            }
        } 
    }

    public Dictionary<int, InventoryItem> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem> returnValue = 
            new Dictionary<int, InventoryItem>();

        for(int i = 0; i < _inventoryItems.Count; i++)
        {
            if (_inventoryItems[i].IsEmpty) continue;

            returnValue[i] = _inventoryItems[i];
        }

        return returnValue;
    }

    public InventoryItem GetItemAt(int itemIndex)
    {
        return _inventoryItems[itemIndex];
    }
}

[Serializable]
public struct InventoryItem
{
    public int quantity;
    public ItemSO item;

    public bool IsEmpty => item == null;

    public InventoryItem ChangeQuantity(int newQuantity)
    {
        return new InventoryItem
        {
            item = this.item,
            quantity = newQuantity,
        };
    }

    public static InventoryItem GetEmptyItem() =>
        new InventoryItem { item = null, quantity = 0 };
}