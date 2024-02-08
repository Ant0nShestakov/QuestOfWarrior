using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private int _count;
    private T _instantiatingObject;
    private Stack<T> _stackObject;
    private bool _isEnded;

    public ObjectPool(int count, T instantiatingObject)
    {
        _count = count;
        _instantiatingObject = instantiatingObject;
        Initialize();
    }

    public ObjectPool(int count, T instantiatingObject, bool isEnded) 
        : this(count, instantiatingObject) => _isEnded = isEnded;

    private void Initialize()
    {
        _stackObject = new Stack<T>();
        for(int i = 0; i < _count ; i++) 
        {
            var instantiatedObject = GameObject.Instantiate(_instantiatingObject);
            SetDefaultStateObject(instantiatedObject);
            _stackObject.Push(instantiatedObject);
        }
    }

    private void SetDefaultStateObject(T returnedObject) =>
        returnedObject.gameObject.SetActive(false);

    public bool TryGetObject(out T getingObject, Vector3 position)
    {
        if (_stackObject.Count == 0 && !_isEnded)
        {
            getingObject = null;
            return false;
        }
        if (_stackObject.Count == 0 && _isEnded)
        {
            getingObject = GameObject.Instantiate(_instantiatingObject);
            getingObject.transform.position = position;
            getingObject.gameObject.SetActive(true);
            return true;
        }
        getingObject = _stackObject.Pop();
        getingObject.transform.position = position;
        getingObject.gameObject.SetActive(true);
        return true;
    }

    public void ReturnObjectToPool(T returnedObject)
    {
        if (returnedObject is not T)
            return;
        SetDefaultStateObject(returnedObject);
        _stackObject.Push(returnedObject);
    }

    public bool ÑheckingForActive()
    {
        if (_stackObject.Count < _count)
            return true;
        return false;
    }
}