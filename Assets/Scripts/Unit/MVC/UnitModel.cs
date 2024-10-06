using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class UnitModel : IDamageable
{
    //private readonly IResistance _resistances;
    private readonly UnitView _unitView;

    private readonly PlayerStats _playerStats;
    private readonly DataPersistanceManager _data;

    private float _currentHealth;
    private float _currentMass;

    public event Action<float> ApplyDamageEvent;
    public event Action<float> ManaEvent;

    //public IResistance Resistances => _resistances; 

    public List<Skill> Cooldowns { get; private set; }

    public float CurrentSpeed { get => PlayerProperites.CurrentSpeed; }

    public float CurrentJumpForce { get => _playerStats.JumpForce; }
    public float CurrentHealth { get => _currentHealth; }
    public float CurrentMass { get => _currentMass; }

    public float Damage { get; set; }

    public bool IsBlocked { get; set; }
    public bool IsAttack { get; set; }

    public Vector3 SavePosition { get; set; }

    public PlayerStats PlayerProperites { get => _playerStats; }
    public InventoryManager InventoryManager { get; private set; }

    public UnitModel(PlayerStats stats, UnitView unitView,
        DataPersistanceManager dataPersistanceManager, InventoryManager inventoryManager)
    {
        _unitView = unitView;

        ApplyDamageEvent += _unitView.UpdateHP;

        ManaEvent += _unitView.UpdateMana;

        _playerStats = stats;

        _data = dataPersistanceManager;

        Cooldowns = new List<Skill>();

        _data.SetPersistances();

        _currentMass = _playerStats.Mass;
        _currentHealth = _playerStats.MaxHealth;
        InventoryManager = inventoryManager;
    }

    public void SetWalkSpeed() => _playerStats.SetWalkSpeed();

    public void SetRunSpeed() => _playerStats.SetRunSpeed();

    public void SetCrouchSpeed() => _playerStats.SetRunSpeed();

    public void SetZeroSpeed() => _playerStats.SetZeroSpeed();

    //public void HealthSelf(int points)
    //{
    //    PlayerProperites.RegenerationHealth(points);
    //    UpdateStatsInfo();
    //}

    public void ApplyDamage(float damage)
    {
        if (!IsBlocked)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
                SceneManager.LoadScene(6);

            ApplyDamageEvent?.Invoke(_currentHealth);
        }
    }

    public void UpdateManaInfo()
    {
        ManaEvent?.Invoke(_playerStats.CurrentStamina);
    }
}