using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractionManager : MonoBehaviour
{
    private event Action _healthAndStaminaEvent;

    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        PlayerModel = GetComponent<PlayerModel>();
        _healthAndStaminaEvent += PlayerModel.UpdateUiInfo;

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
        _healthAndStaminaEvent -= PlayerModel.UpdateUiInfo;        
    }

    public void TakeDamage(int Damage)
    {
        if (PlayerModel.GetDamage(Damage) <= 0 && !PlayerModel.LockState)
        {
            PlayerModel.SetCursorFreeState();
            SceneManager.LoadScene(2);
        }
        _healthAndStaminaEvent.Invoke();
    }
}
