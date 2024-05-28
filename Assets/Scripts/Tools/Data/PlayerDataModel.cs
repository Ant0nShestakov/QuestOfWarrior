using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataModel
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxStamina;

    [SerializeField] private int _currentHealth;
    [SerializeField] private int _currentStamina;
    [SerializeField] private List<SkillData> _skills;

    public int MaxHealth { get => _maxHealth; }
    public int MaxStamina { get => _maxStamina; }
    public int CurrentHealth { get => _currentHealth; }
    public int CurrentStamina { get => _currentStamina; }
    public List<SkillData> Skills { get => _skills; }

    public PlayerDataModel(GameModels playerModel)
    {
        this._maxHealth = playerModel.MaxHealth;
        this._maxStamina = playerModel.MaxStamina;
        this._currentHealth = playerModel.CurrentHealth;
        this._currentStamina = playerModel.CurrentStamina;

        this._skills = new();
    }
}