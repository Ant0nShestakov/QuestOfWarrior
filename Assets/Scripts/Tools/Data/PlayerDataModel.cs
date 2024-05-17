using UnityEngine;

[System.Serializable]
public class PlayerDataModel
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxStamina;

    [SerializeField] private int _currentHealth;
    [SerializeField] private int _currentStamina;

    public int MaxHealth { get => _maxHealth; }
    public int MaxStamina { get => _maxStamina; }
    public int CurrentHealth { get => _currentHealth; }
    public int CurrentStamina { get => _currentStamina; }

    public PlayerDataModel(GameModels playerModel)
    {
        _maxHealth = playerModel.MaxHealth;
        _maxStamina = playerModel.MaxStamina;

        _currentHealth = playerModel.CurrentHealth;
        _currentStamina = playerModel.CurrentStamina;
    }
}