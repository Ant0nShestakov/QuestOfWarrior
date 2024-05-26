using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject[] _hideObject;

    private PlayerModel _playerModel;

    private DataPersistanceManager _presistanceManager;
    private LoadLvL _loadLvL;

    private void Awake()
    {
        _presistanceManager = Singelton<DataPersistanceManager>.Instance;
        _loadLvL = GetComponentInChildren<LoadLvL>();
        _presistanceManager.SetPersistances();
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

                foreach(var item in _hideObject)
                    item.SetActive(false);
            }
        }
    }

    public void OnLoadGameClick() 
    {
        Time.timeScale = 1;
        DontDestroyOnLoad(_presistanceManager);
        _presistanceManager.LoadGame();
        _loadLvL.LoadSceneByIndex();
    }

    public void OnSaveGameClick() => _presistanceManager.SaveGame();

    public void OnNewGameClick()
    {
        Time.timeScale = 1;
        DontDestroyOnLoad(_presistanceManager);
        _presistanceManager.NewGame();
        _loadLvL.LoadSceneByDefaultIndex();
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1;
        Destroy(_presistanceManager.gameObject);
        SceneManager.LoadScene(0);
    }
}
