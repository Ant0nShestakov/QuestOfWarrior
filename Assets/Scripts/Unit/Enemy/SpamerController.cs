using System;
using UnityEngine;
using Zenject;

public class SpamerController : MonoBehaviour, IDataPersistance
{
    [Inject] private readonly IObjectPool<EnemyManager> _enemyPool;

    [SerializeField] private Transform _spamerTransform;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _xSpread;
    [SerializeField] private float _zSpread;

    [SerializeField] private string _id;

    #region Generate Guid tools 
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        _id = Guid.NewGuid().ToString();

        #if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
    #endregion

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponentInParent<UnitController>() != null)
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                Vector3 spamPosition = new Vector3(_spamerTransform.position.x + _xSpread,
                    _spamerTransform.position.y, _spamerTransform.position.z + _zSpread);
                if (_enemyPool.TryPop(out EnemyManager enemy, spamPosition))
                {
                    _xSpread += 1;
                    _zSpread += 1;
                }
                else
                    Debug.LogError("Not Pop");
            }
            gameObject.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        var spamer = data.SpamersSelfAcitve.Find(spamer => spamer.SpamerID == _id);
        if (spamer == null)
        {
            Debug.Log($"Spamer {_id} not found. Load default value");
            return;
        }
        this.gameObject.SetActive(spamer.AcitveSelf);
    }

    public void SaveData(ref GameData data)
    {
        bool acitve = this.gameObject.activeSelf;
        Debug.Log($"Active: {acitve}");

        var spamer = data.SpamersSelfAcitve.Find(spamer => spamer.SpamerID == _id);

        if (spamer == null)
        {
            Debug.Log($"Spamer {_id} not found. Add Spamer tu list");
            data.SpamersSelfAcitve.Add(new SpamerInfoData(_id, acitve));
            return;
        }
        int index = data.SpamersSelfAcitve.IndexOf(spamer);
        Debug.Log($"Spamer {_id} found for index {index}. Update value)");
        data.SpamersSelfAcitve[index] = new SpamerInfoData(_id, acitve);
    }
}
