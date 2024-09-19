using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScritableObjects/Stats/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [field: SerializeField] public int AutoAttackDamage { get; private set; }
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public int MaxStamina { get; set; }
    [field: SerializeField] public int RegenerationStaminaOnTick { get; private set; }
    [field: SerializeField] public float TickRegenerationInSeconds { get; private set; }
    [field: SerializeField] public int WalkSpeed { get; private set; }
    [field: SerializeField] public float RunSpeedModificator { get; private set; }
    [field: SerializeField] public int SwimSpeedModificator { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float Mass { get; private set; }

    public float CurrentHealth { get; set; }
    public int CurrentStamina { get; set; }
    public float CurrentSpeed { get; set; }

    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
        CurrentStamina = MaxStamina;
        SetWalkSpeed();
    }

    public void RegenerationStamina()
    {
        CurrentStamina += RegenerationStaminaOnTick;

        if (CurrentStamina > MaxStamina)
            CurrentStamina = MaxStamina;
    }

    public void RegenerationStamina(int points)
    {
        CurrentStamina += points;

        if (CurrentStamina > MaxStamina)
            CurrentStamina = MaxStamina;
    }

    public void RegenerationHealth(int points)
    {
        CurrentHealth += points;
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    public void SetWalkSpeed() => CurrentSpeed = WalkSpeed;

    public void SetSwimSpeed() => CurrentSpeed *= SwimSpeedModificator;

    public void SetRunSpeed() => CurrentSpeed *= RunSpeedModificator;

    public void SetZeroSpeed() => CurrentSpeed = 0;

    public void SetDefaultState()
    {
        CurrentHealth = MaxHealth;
        CurrentStamina = MaxStamina;
        CurrentSpeed = WalkSpeed;
    }
}
