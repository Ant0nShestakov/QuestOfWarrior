using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LoadLvL : MonoBehaviour, IDataPersistance
{
    [SerializeField] private int _defIndex;
    private int _index;

    private DataPersistanceManager _manager;

    [Inject]
    public void Construct(DataPersistanceManager manager)
    {
        _manager = manager;
    }

    private void Start()
    {
        _manager = Singleton<DataPersistanceManager>.Instance;
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

    public void LoadMainMenu() =>
        SceneManager.LoadScene(0);
}
