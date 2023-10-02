using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private UIInventoryItem _inventoryItem;

    public void Awake()
    {
        _canvas = transform.root.GetComponent<Canvas>();
        _inventoryItem = GetComponentInChildren<UIInventoryItem>();
    }

    public void SetData(Sprite sprite, int count)
    {
        _inventoryItem.SetData(sprite, count);
    }

    private void Update()
    {
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)_canvas.transform,
                                                                Input.mousePosition, _canvas.worldCamera, out position);

        transform.position = _canvas.transform.TransformPoint(position);
    }

    public void Toggle(bool value)
    {
        Debug.Log($"Item toggled {value}");
        gameObject.SetActive(value);
    }
}