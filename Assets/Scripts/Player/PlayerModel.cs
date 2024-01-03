using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private GameModels _playerProperites;

    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public bool LockState { get; set; }
    [field: SerializeField] public bool IsBlocked { get; set; }

    private void Awake()
    {
        Health = _playerProperites.Health;
        Damage = _playerProperites.Damage;
    }

    public void SetCursorLockState()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetCursorFreeState()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public int GetDamage(int Damage)
    {
        if(!IsBlocked)
            Health -= Damage;
        return Health;
    }
}
