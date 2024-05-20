using UnityEngine;

[System.Serializable]
public class ObjectPosition
{
    [SerializeField] private int _indexScene;
    [SerializeField] private Vector3 _position;

    public int IndexScene { get => _indexScene; }
    public Vector3 Position { get => _position; }

    public ObjectPosition(int indexScene, Vector3 position)
    {
        this._indexScene = indexScene;
        this._position = position;
    }
}