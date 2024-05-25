using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvL : MonoBehaviour, IDataPersistance
{
    [SerializeField] private int _defIndex;
    private int _index;

    private DataPersistanceManager _manager;

    private void Start()
    {
        _manager = Singelton<DataPersistanceManager>.Instance;
    }
    
    public void LoadData(GameData data)
    {
        Debug.Log(data.SceneIndex);
        _index = data.SceneIndex;
    }

    public void LoadSceneByIndex()
    {
        Time.timeScale = 1;
        Debug.Log(_index);
        SceneManager.LoadScene(_index);
    }

    public void LoadSceneByDefaultIndex()
    {
        _manager.SaveGame();
        Time.timeScale = 1;
        SceneManager.LoadScene(_defIndex);
    }

    public void SaveData(ref GameData data)
    {
        return;
    }
}
