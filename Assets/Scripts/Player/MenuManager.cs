using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private PlayerModel _playerModel;

    private DataPersistanceManager _presistanceManager;

    private void OnEnable()
    {
        _presistanceManager = Singelton<DataPersistanceManager>.Instance;
    }

    private void Start()
    {
        Time.timeScale = 1;
        _playerModel = GetComponentInParent<PlayerModel>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _menu != null )
        {
            if(_menu.activeSelf)
            {
                _playerModel.SetCursorLockState();
                _menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                _playerModel.SetCursorFreeState();
                _menu.SetActive(true);
            }
        }
    }

    public void OnLoadGameClick() 
    {
        Time.timeScale = 1;
        DontDestroyOnLoad(_presistanceManager);
        SceneManager.LoadScene(1);
        //_presistanceManager.SetPersistances();
        //_presistanceManager.LoadGame();
    }

    public void OnSaveGameClick() => _presistanceManager.SaveGame();

    public void OnNewGameClick() => _presistanceManager.NewGame();

}
