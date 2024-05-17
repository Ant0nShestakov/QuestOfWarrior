using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField] private PlayerDataModel _playerModel;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private Quaternion _playerRotation;

    public PlayerDataModel PlayerModel { get => _playerModel; set => _playerModel = value; }
    public Vector3 PlayerPosition { get => _playerPosition; set => _playerPosition = value; }

    public GameData() 
    {
    }
}