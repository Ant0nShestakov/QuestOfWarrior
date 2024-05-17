using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    [SerializeField] private string _fileName;

    private GameData _gameData;
    private FileDataHandler _fileHandler;
    private List<IDataPersistance> _persistances;

    public static DataPersistanceManager Instance;

    private void Start()
    {
        _fileHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
        _persistances = FindAllDataPersistances();
    }

    public void SetPersistances()
    {
        Debug.Log("I alive");
        _persistances = FindAllDataPersistances();
        foreach(IDataPersistance p in  _persistances)
        {
            Debug.Log(p.ToString());
        }
    }

    public void NewGame()
    {
        _gameData = new GameData();
    }

    public void LoadGame()
    {
        Debug.Log("I load");
        _gameData = _fileHandler.Load();

        if (_gameData == null)
        {
            Debug.Log("Булочка с сосикою");
            NewGame();
        }

        foreach(IDataPersistance persistance in _persistances)
        {
            persistance.LoadData(_gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistance persistance in _persistances)
            persistance.SaveData(ref _gameData);

        _fileHandler.Save(_gameData);
    }

    private List<IDataPersistance> FindAllDataPersistances()
    {
        IEnumerable<IDataPersistance> dataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistances);
    }

    //private void OnApplicationQuit()
    //{
    //    SaveGame();
    //}
}
