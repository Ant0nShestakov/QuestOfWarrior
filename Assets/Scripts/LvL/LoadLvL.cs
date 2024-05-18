using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvL : MonoBehaviour, IDataPersistance
{
    [SerializeField] private int _defIndex;
    private int _index;

    public void LoadData(GameData data)
    {
        _index = data.SceneIndex;
    }

    public void LoadSceneByIndex()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_index);
    }

    public void LoadSceneByDefaultIndex()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_defIndex);
    }

    public void SaveData(ref GameData data)
    {
        return;
    }
}
