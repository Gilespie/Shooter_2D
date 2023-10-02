using System;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage _inventoryUI;
    [SerializeField] private InventorySO _inventoryData;

    private void Start()
    {
        PrepareUI();
        //_inventoryData.Initialize();
    }

    private void PrepareUI()
    {
        _inventoryUI.InitializeInventoryUI(_inventoryData.Size);
        this._inventoryUI.OnDescrtiptionRequested += HandleDescriptionRequest;
        this._inventoryUI.OnStartDragging += HandleDragging;
        this._inventoryUI.OnSwapItems += HandleSwapItem;
        this._inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);

        if (inventoryItem.IsEmpty) return;

        ItemSO item = inventoryItem.item;
        _inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.name, item.Description);

                                    
    }

    private void HandleItemActionRequest(int itemIndex)
    {
        
    }

    private void HandleSwapItem(int itemIndex_1, int itemIndex_2)
    {
        
    }

    private void HandleDragging(int itemIndex)
    {
       
    }

    public void OpenInventory()
    {
        _inventoryUI.ShowInventory();
           
        foreach(var item in _inventoryData.GetCurrentInventoryState())
        {
            _inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
        }
    }

    public void CloseInventory()
    {
        _inventoryUI.HideInventory();
    }
}