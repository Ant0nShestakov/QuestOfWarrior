using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPool<T> : IObjectPool<T> where T : MonoBehaviour, IPooledObject<T>
{
    private int _count;
    private readonly T _instantiatingObject;
    private Stack<T> _stackObject;
    private readonly bool _isEnded;

    [Inject]
    public ObjectPool(int count, T instantiatingObject, bool isEnded = false)
    { 
        _isEnded = isEnded;
        _count = count;
        _instantiatingObject = instantiatingObject;
        Initialize();
    }

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

    public int GetCurrentCount() => _stackObject.Count;

    public int GetMaxCount() => _count;

    public bool TryPop(out T getingObject, Vector3 position)
    {
        if (_stackObject.Count == 0 && !_isEnded)
        {
            getingObject = null;
            return false;
        }
        if (_stackObject.Count == 0 && _isEnded)
        {
            Debug.Log("Instatiate");
            _count++;
            getingObject = GameObject.Instantiate(_instantiatingObject);
            getingObject.transform.position = position;
            getingObject.gameObject.SetActive(true);
            getingObject.PushEvent += Push;
            return true;
        }
        getingObject = _stackObject.Pop();
        getingObject.transform.position = position;
        getingObject.gameObject.SetActive(true);

        getingObject.PushEvent += Push;

        return true;
    }

    public void Push(T returnedObject)
    {
        if (returnedObject is not T)
        {
            Debug.Log($"{nameof(returnedObject)} is not {typeof(T)}");
            return;
        }
        SetDefaultStateObject(returnedObject);
        Debug.Log($"{nameof(returnedObject)} return to Pool");
        _stackObject.Push(returnedObject);
    }

    public bool ÑheckingForActive()
    {
        if (_stackObject.Count < _count)
            return true;
        return false;
    }
}