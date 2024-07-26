using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryItem _itemPrefab;
    [SerializeField] private Transform _transformItem;
    [SerializeField] private int _maxCount;
    [SerializeField] private int _minCount;
    [SerializeField] private bool _isAdded;

    [SerializeField] private List<Item> _items;
    private ObjectPool<InventoryItem> _pool;
    private List<InventoryItem> _inventoryCache;

    private void Awake()
    {
        _pool = new ObjectPool<InventoryItem>(_minCount, _itemPrefab, _isAdded);
        _inventoryCache = new List<InventoryItem>();
    }

    public void Add(Item item)
    {
        if(_pool.GetCurrentCount() < _maxCount)
            _items.Add(item);

        _items.OrderBy(item => item.Name);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
        _items.OrderBy(item => item.Name);
        CloseInventory();
        ShowInventory();
    }

    public void ShowInventory()
    {
        Debug.Log(_pool.GetCurrentCount());
        foreach (var item in _items) 
        {
            if (_pool.TryPop(out InventoryItem inventoryItem, _transformItem.position))
            { 
                inventoryItem.transform.SetParent(_transformItem);
                inventoryItem.transform.localScale = Vector3.one;

                var itemName = inventoryItem.transform.Find("ItemName").GetComponent<TMP_Text>();
                var iconItem = inventoryItem.transform.Find("IconItem").GetComponent<Image>();
                itemName.text = item.Name;
                iconItem.sprite = item.Image;

                var itemButton = inventoryItem.GetComponent<Button>();
                itemButton.onClick.AddListener(() => inventoryItem.UseItem(item));

                var childernButton = inventoryItem.transform.Find("Close").GetComponent<Button>();

                childernButton.onClick.AddListener(() =>
                {
                    Remove(item);
                    Debug.Log("Removed");
                });

                _inventoryCache.Add(inventoryItem);
            }
        }
    }

    public void CloseInventory()
    {
        foreach (var item in _inventoryCache)
        {
            var itemButton = item.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            var childernButton = item.GetComponent<Button>();
            childernButton.onClick.RemoveAllListeners();
            _pool.Push(item);
        }
        _inventoryCache.Clear();
    }
}
