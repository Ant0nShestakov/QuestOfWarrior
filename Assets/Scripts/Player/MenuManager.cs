using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private PlayerModel _playerModel;

    private void Start()
    {
        Time.timeScale = 1;
        _playerModel = GetComponentInParent<PlayerModel>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        //_playerModel.LockState = _menu.activeSelf;
    }
}
