using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    private EnemyModel _enemyModel;

    private void Start() => _enemyModel = GetComponent<EnemyModel>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable player))
        {
            if (player as EnemyModel)
                return;
            player.ApplyDamage(_enemyModel.Damage);
        }
    }
}
