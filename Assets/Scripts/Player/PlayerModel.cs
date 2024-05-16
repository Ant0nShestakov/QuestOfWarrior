using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private GameModels _playerProperites;
    private HealthBar _healthBar; 
    private Dictionary<CooldownTypes, float> _cooldowns;

    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Stamina { get; private set; }
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public int Speed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float Gravity { get; private set; }
    [field: SerializeField] public bool LockState { get; set; }
    [field: SerializeField] public bool IsBlocked { get; set; }
    [field: SerializeField] public bool IsStay { get; set; }
    [field: SerializeField] public List<Cooldown> Cooldowns { get; set; }

    public bool IsOnGround { get; set; }
    public bool IsSwim { get; set; }
    public bool IsFreeFly { get; set; }
    [field: SerializeField] public bool IsAttack { get; private set; }

    private void Awake()
    {
        Health = _playerProperites.Health;
        Damage = _playerProperites.AutoAttackDamage;
        Stamina = _playerProperites.MaxStamina;
        Speed = _playerProperites.WalkSpeed;
        JumpForce = _playerProperites.JumpForce;
        Gravity = _playerProperites.Gravity;
        _healthBar = GetComponentInChildren<HealthBar>();

        _cooldowns = new ();

        //foreach(var item in Cooldowns)
        //{
        //    _cooldowns.Add(item.Type, )
        //}

    }

    private void OnDisable()
    {
        foreach(var cooldown in Cooldowns)
            cooldown.SetDefaultState();
    }

    private bool CheckStaminaForAttack(Cooldown cd)
    {
        if (Stamina - cd.Stamina < 0)
            return false;
        return true;
    }

    private bool TryGetCooldownForType(CooldownTypes cooldownTypes, out Cooldown cooldown)
    {
        cooldown = Cooldowns.SingleOrDefault(cd => cd.Type == cooldownTypes);

        if(cooldown is null) 
            return false;

        return true;
    }

    public bool TryCast(CooldownTypes cooldownTypes, float time)
    {
        if (!IsOnGround || IsAttack)
            return false;

        if (!TryGetCooldownForType(cooldownTypes, out Cooldown cooldown))
            return false;

        if (!CheckStaminaForAttack(cooldown))
            return false;

        if (!cooldown.CheckCooldownStemp(time))
            return false;

        Damage = cooldown.Damage;
        Stamina -= cooldown.Stamina;
        return true;
    }

    public void SetWalkSpeedState() 
    {
        IsStay = false;
        Speed = _playerProperites.WalkSpeed;
    }

    public bool Attacking() => IsAttack = true;
    public bool NoAttacking() => IsAttack = false;

    public void SetRunSpeedState() => Speed = _playerProperites.RunSpeed;

    public void SetSwimSpeedState() => Speed = _playerProperites.SwimSpeed;

    public void Stay() 
    {
        IsStay = true;
        Speed = 0; 
    }

    public bool CheckRegenerationStamina() => 
        Stamina + _playerProperites.RegenerationStamina < _playerProperites.MaxStamina;

    public void RegenerationStamina() 
    {
        if (Stamina + _playerProperites.RegenerationStamina >= _playerProperites.MaxStamina)
            Stamina = _playerProperites.MaxStamina;
        else
            Stamina += _playerProperites.RegenerationStamina;

        _healthBar.UpdateInfo();
    }

    public void SetCursorLockState()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        LockState = false;
    }

    public void HelthSelf(int points)
    {
        Health += points;
        if (Health > _playerProperites.Health)
            Health = _playerProperites.Health;
        _healthBar.UpdateInfo();
    }

    public void EnergyRegen(int points)
    {
        Stamina += points;
        if (Stamina > _playerProperites.MaxStamina)
            Stamina = _playerProperites.MaxStamina;
        _healthBar.UpdateInfo();
    }

    public void SetCursorFreeState()
    {
        Cursor.lockState = CursorLockMode.None;
        LockState = true;
    }

    public int GetDamage(int Damage)
    {
        if(!IsBlocked)
            Health -= Damage;
        return Health;
    }
}
