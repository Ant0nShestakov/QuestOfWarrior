using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvL : MonoBehaviour
{
    [SerializeField] private int index;

    public void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
}
