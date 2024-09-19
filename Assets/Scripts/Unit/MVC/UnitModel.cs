using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class UnitModel : IDamageable
{
    //private readonly UnitStats _stats;
    //private readonly IResistance _resistances;

    private readonly PlayerStats _playerStats;
    private readonly DataPersistanceManager _data;

    private float _currentHealth;
    private float _currentMass;

    public event Action UpdateStatsEvent;

    //public IResistance Resistances => _resistances; 

    public List<Skill> Cooldowns { get; private set; }

    public float CurrentSpeed { get => PlayerProperites.CurrentSpeed; }

    public float CurrentJumpForce { get => _playerStats.JumpForce; }
    public float CurrentHealth { get => _currentHealth; }
    public float CurrentMass { get => _currentMass; }

    public float Damage { get; set; }

    public bool IsBlocked { get; set; }
    public bool IsLocked { get; set; }
    public bool IsAttack { get; set; }
    
    public Vector3 SavePosition { get; set; }

    public PlayerStats PlayerProperites { get => _playerStats; }
    public InventoryManager InventoryManager { get; private set; }

    public UnitModel(PlayerStats stats, DataPersistanceManager dataPersistanceManager, InventoryManager inventoryManager)
    {
        _playerStats = stats;
        _data = dataPersistanceManager;
        _data.SetPersistances();

        _currentMass = _playerStats.Mass;
        _currentHealth = _playerStats.MaxHealth;
        InventoryManager = inventoryManager;
    }

    public void SetWalkSpeed() => _playerStats.SetWalkSpeed();

    public void SetRunSpeed() => _playerStats.SetRunSpeed();

    public void SetCrouchSpeed() => _playerStats.SetRunSpeed();

    public void SetZeroSpeed() => _playerStats.SetZeroSpeed();

    public void SetCursorLockState()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        IsLocked = false;
    }

    //public void HealthSelf(int points)
    //{
    //    PlayerProperites.RegenerationHealth(points);
    //    UpdateStatsInfo();
    //}

    public void SetCursorFreeState()
    {
        Cursor.lockState = CursorLockMode.None;
        IsLocked = true;
    }

    public void ApplyDamage(float damage)
    {
        if (!IsBlocked)
        {
            PlayerProperites.CurrentHealth -= damage;

            if (PlayerProperites.CurrentHealth <= 0)
                SceneManager.LoadScene(6);

            UpdateStatsEvent?.Invoke();
        }
    }
}