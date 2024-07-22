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
    [field: SerializeField] public int RunSpeed { get; private set; }
    [field: SerializeField] public int SwimSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float Gravity { get; private set; }

    public float CurrentHealth { get; set; }
    public int CurrentStamina { get; set; }
    public int CurrentSpeed { get; set; }

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

    public void SetSwimSpeed() => CurrentSpeed = SwimSpeed;

    public void SetRunSpeed() => CurrentSpeed = RunSpeed;

    public void SetDefaultState()
    {
        CurrentHealth = MaxHealth;
        CurrentStamina = MaxStamina;
        CurrentSpeed = WalkSpeed;
    }
}
