using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class SpamerController : MonoBehaviour, IDataPersistance
{
    [SerializeField] private Transform _spamerTransform;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _xSpread;
    [SerializeField] private float _zSpread;

    [SerializeField] private string _id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        _id = Guid.NewGuid().ToString();

        #if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }


    //private long GetLocalIdentifierInFile()
    //{
    //    #if UNITY_EDITOR
    //    PropertyInfo inspectorModeInfo = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
    //    SerializedObject serializedObject = new SerializedObject(this);
    //    inspectorModeInfo.SetValue(serializedObject, InspectorMode.Debug, null);
    //    SerializedProperty localIdProp = serializedObject.FindProperty("m_LocalIdentfierInFile"); // Note the misspelling!
    //    return localIdProp.longValue;
    //    #else
    //        int instanceID = GetInstanceID();
    //        return instanceID;
    //    #endif
    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerInteractionManager _))
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                Vector3 spamPosition = new Vector3(_spamerTransform.position.x +_xSpread,
                    _spamerTransform.position.y,_spamerTransform.position.z + _zSpread);
                if (_enemyPool.ObjectPoolEnemy.TryGetObject(out EnemyManager enemy, spamPosition))
                {
                    _xSpread += 1;
                    _zSpread += 1;
                }
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
