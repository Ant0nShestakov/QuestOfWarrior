using UnityEngine;

[System.Serializable]
public class SpamerInfoData
{
    [SerializeField] private long _spamerId;
    [SerializeField] private bool _activeSelf;

    public long SpamerID { get => _spamerId; }
    public bool AcitveSelf { get => _activeSelf; }

    public SpamerInfoData(long id, bool isActive)
    {
        this._spamerId = id;
        this._activeSelf = isActive;
    }
}