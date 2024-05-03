using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractionManager : MonoBehaviour
{
    private event Action _healthAndStaminaEvent;
    private HealthBar _healthBar;

    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        PlayerModel = GetComponent<PlayerModel>();
    }

    private void OnEnable()
    {
        _healthBar = GetComponentInChildren<HealthBar>();
        _healthAndStaminaEvent += UpdateUiInfo;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<DoorManager>(out DoorManager door))
        {
            if (Input.GetKey(KeyCode.E) && !PlayerModel.LockState)
                door.OpenDoor();
            return;
        }
    }

    private void OnDisable()
    {
        _healthAndStaminaEvent -= UpdateUiInfo;        
    }

    public void UpdateUiInfo() => _healthBar.UpdateInfo();

    public void TakeDamage(int Damage)
    {
        if (PlayerModel.GetDamage(Damage) <= 0)
        {
            PlayerModel.SetCursorFreeState();
            SceneManager.LoadScene(2);
        }
        _healthAndStaminaEvent.Invoke();
    }
}
