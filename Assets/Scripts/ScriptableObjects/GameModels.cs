using UnityEngine;

[CreateAssetMenu(fileName = "GameModels", menuName = "ScritableObjects/Models")]
public class GameModels : ScriptableObject
{
    [field: SerializeField] public int AutoAttackDamage { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int MaxStamina { get; private set; }
    [field: SerializeField] public int RegenerationStamina { get; private set; }
    [field: SerializeField] public float RegenerationCooldownInSeconds { get; private set; }
    [field: SerializeField] public int WalkSpeed { get; private set; }
    [field: SerializeField] public int RunSpeed { get; private set; }
    [field: SerializeField] public int SwimSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float Gravity { get; private set; }
}
