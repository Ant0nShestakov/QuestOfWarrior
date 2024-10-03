using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataModel
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _maxStamina;

    [SerializeField] private float _currentHealth;
    [SerializeField] private float _currentStamina;
    [SerializeField] private List<SkillData> _skills;

    public float MaxHealth { get => _maxHealth; }
    public float MaxStamina { get => _maxStamina; }
    public float CurrentHealth { get => _currentHealth; }
    public float CurrentStamina { get => _currentStamina; }
    public List<SkillData> Skills { get => _skills; }

    public PlayerDataModel(PlayerStats playerModel)
    {
        this._maxHealth = playerModel.MaxHealth;
        this._maxStamina = playerModel.MaxStamina;
        this._currentHealth = playerModel.CurrentHealth;
        this._currentStamina = playerModel.CurrentStamina;

        this._skills = new();
    }
}