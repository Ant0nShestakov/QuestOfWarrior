using System;
using UnityEngine;

[System.Serializable]
public class SpamerInfoData
{
    [SerializeField] private string _spamerId;
    [SerializeField] private bool _activeSelf;

    public string SpamerID { get => _spamerId; }
    public bool AcitveSelf { get => _activeSelf; }

    public SpamerInfoData(string id, bool isActive)
    {
        this._spamerId = id;
        this._activeSelf = isActive;
    }
}