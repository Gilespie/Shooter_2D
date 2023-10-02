using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem _itemPrefab;
    [SerializeField] private RectTransform _contentPanel;
    [SerializeField] private UIInventoryDescription _itemDescription;
    [SerializeField] private MouseFollower _mouseFollower;
    private List<UIInventoryItem> _listOfUIItems = new List<UIInventoryItem>();
    private int _currentlyDraggedItemIndex = -1;


    public event Action<int> OnDescrtiptionRequested, OnItemActionRequested, OnStartDragging;
    public event Action<int, int> OnSwapItems;

    private void Awake()
    {
        HideInventory();
        _mouseFollower.Toggle(false);
        _itemDescription.ResetDescription();
    }

    public void InitializeInventoryUI(int inventorySize)
    {
        for(int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem uiitem = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            uiitem.transform.SetParent(_contentPanel);
            _listOfUIItems.Add(uiitem);

            uiitem.OnItemClicked += HandleItemSelection;
            uiitem.OnItemBeginDrag += HandleBeginDrag;
            uiitem.OnItemDroppedOn += HandleSwap;
            uiitem.OnItemEndDrag += HandleEndDrag;
            uiitem.OnRightMouseButtonClick += HandleShowItemActions;
        }
    }

    internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
    {
        _itemDescription.SetDescription(itemImage, name, description);
        DeselectAllItems();
        _listOfUIItems[itemIndex].Select();
    }

    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if(_listOfUIItems.Count > itemIndex)
        {
            _listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
        }
    }

    private void HandleShowItemActions(UIInventoryItem inventoryItemUI)
    {
        
    }

    private void HandleEndDrag(UIInventoryItem inventoryItemUI)
    {
        ResetDraggedItem();
    }

    private void HandleSwap(UIInventoryItem inventoryItemUI)
    {
        int index = _listOfUIItems.IndexOf(inventoryItemUI);

        if (index == -1)
        {

            return;
        }

        OnSwapItems?.Invoke(_currentlyDraggedItemIndex, index);
    }

    private void ResetDraggedItem()
    {
        _mouseFollower.Toggle(false);
        _currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
    {
        int index = _listOfUIItems.IndexOf(inventoryItemUI);

        if (index == -1) return;

        _currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }

    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        _mouseFollower.Toggle(true);
        _mouseFollower.SetData(sprite, quantity);
    }

    private void HandleItemSelection(UIInventoryItem inventoryItemUI)
    {
        int index = _listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1) return;

        OnDescrtiptionRequested?.Invoke(index);
    }

    public void ShowInventory()
    {
        gameObject.SetActive(true);
        ResetSelection();
        _itemDescription.ResetDescription();
    }

    public void ResetSelection()
    {
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach(UIInventoryItem item in _listOfUIItems)
        {
            item.Deselect();
        }
    }

    public void HideInventory()
    {
        gameObject.SetActive(false);
        ResetDraggedItem();
    }
}