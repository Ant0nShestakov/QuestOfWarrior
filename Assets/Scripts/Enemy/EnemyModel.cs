using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [SerializeField] private GameModels _EnemyProperites;

    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }

    private void Start()
    {
        Health = _EnemyProperites.Health;
        Damage = _EnemyProperites.AutoAttackDamage;
    }

    public int GetDamage(int Damage)
    {
        Health -= Damage;
        return Health;
    }

    public void SetDefaultState()
    {
        Health = _EnemyProperites.Health;
        Damage = _EnemyProperites.AutoAttackDamage;
    }
}
