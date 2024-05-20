using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField] private PlayerDataModel _playerModel;
    [SerializeField] private Quaternion _playerRotation;
    [SerializeField] private int _sceneIndex;
    [SerializeField] private List<ObjectPosition> _positions;
    [SerializeField] private List<SpamerInfoData> _spamersSelfActive;

    public PlayerDataModel PlayerModel { get => _playerModel; set => _playerModel = value; }
    public List<ObjectPosition> PlayerPosition { get => _positions; }
    public List<SpamerInfoData> SpamersSelfAcitve { get => _spamersSelfActive; }
    public int SceneIndex { get => _sceneIndex; set => _sceneIndex = value; }

    public GameData() 
    {
        _positions = new List<ObjectPosition>();
        _spamersSelfActive = new List<SpamerInfoData>();
    }
}