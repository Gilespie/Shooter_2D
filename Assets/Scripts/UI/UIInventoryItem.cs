using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public event Action<UIInventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseButtonClick;
    
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _borderImage;
    [SerializeField] private TextMeshProUGUI _itemQuantity;
    private bool isEmpty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        _itemImage.gameObject.SetActive(false);
        isEmpty = true;
    }

    public void Deselect()
    {
        _borderImage.enabled = false;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        _itemImage.gameObject.SetActive(true);
        _itemImage.sprite = sprite;
        _itemQuantity.text = quantity + "";
        isEmpty = false;
    }

    public void Select()
    {
        _borderImage.enabled = true;
    }

    public void OnPointerClick(PointerEventData pointerData)
    {
        if (pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseButtonClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isEmpty) return;

        OnItemBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}