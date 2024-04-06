using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private GameModels _playerProperites;

    private HealthBar _healthBar;

    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Stamina { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Speed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public bool LockState { get; set; }
    [field: SerializeField] public bool IsBlocked { get; set; }
    [field: SerializeField] public bool IsStay { get; set; }

    private void Awake()
    {
        Health = _playerProperites.Health;
        Damage = _playerProperites.AutoAttackDamage;
        Stamina = _playerProperites.MaxStamina;
        Speed = _playerProperites.WalkSpeed;
        JumpForce = _playerProperites.JumpForce;
        _healthBar = Singelton<HealthBar>.Instance;
    }

    public void SetAutoAttackDamage() => Damage = _playerProperites.AutoAttackDamage;

    public void SetSpecialFastAttackDamage()
    {
        Stamina -= _playerProperites.UsingStaminaForSpecialFastAttack;
        Damage = _playerProperites.SpecialFastAttackDamage;
        UpdateUiInfo();
    }

    public void SetSpecialStrongAttackDamage() 
    {
        Stamina -= _playerProperites.UsingForStaminaSpecialStrongAttack;
        Damage = _playerProperites.SpecialStrongAttackDamage;
        UpdateUiInfo();
    }

    public void SetWalkSpeedState() 
    {
        IsStay = false;
        Speed = _playerProperites.WalkSpeed;
    }

    public void SetRunSpeedState() => Speed = _playerProperites.RunSpeed;

    public void Stay() 
    {
        IsStay = true;
        Speed = 0; 
    }

    public bool CheckStaminaForAttack(AttackState state)
    {
        if (state is SpecialFastAttackState)
            if (Stamina - _playerProperites.UsingStaminaForSpecialFastAttack < 0)
                return false;
        if (state is SpecialStrongAttackState)
            if (Stamina - _playerProperites.UsingForStaminaSpecialStrongAttack < 0)
                return false;
        return true;
    }

    public bool CheckRegenerationStamina() => 
        Stamina + _playerProperites.RegenerationStamina < _playerProperites.MaxStamina;

    public void RegenerationStamina() 
    {
        if (Stamina + _playerProperites.RegenerationStamina >= _playerProperites.MaxStamina)
            Stamina = _playerProperites.MaxStamina;
        else
            Stamina += _playerProperites.RegenerationStamina;
        UpdateUiInfo();
    }

    public void SetCursorLockState()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateUiInfo() => _healthBar.UpdateInfo();

    public void SetCursorFreeState() => Cursor.lockState = CursorLockMode.None;

    public int GetDamage(int Damage)
    {
        if(!IsBlocked)
            Health -= Damage;
        return Health;
    }
}
