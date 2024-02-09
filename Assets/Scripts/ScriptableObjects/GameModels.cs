using UnityEngine;

[CreateAssetMenu(fileName = "GameModels", menuName = "ScritableObjects/Models")]
public class GameModels : ScriptableObject
{
    [field: SerializeField] public int AutoAttackDamage { get; private set; }
    [field: SerializeField] public int SpecialStrongAttackDamage { get; private set; }
    [field: SerializeField] public int SpecialFastAttackDamage { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int MaxStamina { get; private set; }
    [field: SerializeField] public int WalkSpeed { get; private set; }
    [field: SerializeField] public int RunSpeed { get; private set; }
}
