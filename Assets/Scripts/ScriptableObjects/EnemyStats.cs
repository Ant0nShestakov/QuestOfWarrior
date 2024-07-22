using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScritableObjects/Stats/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int WalkSpeed { get; private set; }
    [field: SerializeField] public int RunSpeed { get; private set; }
    [field: SerializeField] public int DistancePerAttack { get; private set; }
}
