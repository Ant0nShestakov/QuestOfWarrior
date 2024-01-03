using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvL : MonoBehaviour
{
    [SerializeField] private int index;

    public void LoadScene()
    {
        SceneManager.LoadScene(index);
    }
}
