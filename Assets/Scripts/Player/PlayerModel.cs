using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private GameModels _playerProperites;

    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Speed { get; private set; }
    [field: SerializeField] public bool LockState { get; set; }
    [field: SerializeField] public bool IsBlocked { get; set; }
    [field: SerializeField] public bool IsStay { get; set; }

    private void Awake()
    {
        Health = _playerProperites.Health;
        Damage = _playerProperites.AutoAttackDamage;
        Speed = _playerProperites.WalkSpeed;
    }

    public void SetAutoAttackDamage() => Damage = _playerProperites.AutoAttackDamage;
    public void SetSpecialFastAttackDamage() => Damage = _playerProperites.SpecialFastAttackDamage;
    public void SetSpecialStrongAttackDamage() => Damage = _playerProperites.SpecialStrongAttackDamage;

    public void SetWalkSpeedState() 
    {
        IsStay = false;
        Speed = _playerProperites.WalkSpeed;
    }
    

    public void SetRunSpeedState()
    {
        Speed = _playerProperites.RunSpeed;
    }

    public void Stay() 
    {
        IsStay = true;
        Speed = 0; 
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
