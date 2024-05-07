using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{

    [SerializeField] private List<Item> _items;
    private Stack<Item> _stack;

    private void Start()
    {
        _stack = new Stack<Item>();
        foreach (var item in _items)
            _stack.Push(item);
    }

    public bool TryGetItems(out Item item)
    {
        if (_stack.Count != 0)
        {
            item = _stack.Pop();
            return true;
        }
        item = null;
        return false;
    }
}
