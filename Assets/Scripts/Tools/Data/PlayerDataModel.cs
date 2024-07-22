using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataModel
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxStamina;

    [SerializeField] private float _currentHealth;
    [SerializeField] private int _currentStamina;
    [SerializeField] private List<SkillData> _skills;

    public int MaxHealth { get => _maxHealth; }
    public int MaxStamina { get => _maxStamina; }
    public float CurrentHealth { get => _currentHealth; }
    public int CurrentStamina { get => _currentStamina; }
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