using UnityEngine;

[System.Serializable]
public class ObjectPosition
{
    [SerializeField] private int _indexScene;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;

    public int IndexScene { get => _indexScene; }
    public Vector3 Position { get => _position; }
    public Quaternion Rotation { get => _rotation; }

    public ObjectPosition(int indexScene, Vector3 position, Quaternion rotation)
    {
        _indexScene = indexScene;
        _position = position;
        _rotation = rotation;
    }
}