using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    private EnemyModel _enemyModel;

    private void Start()
    {
        _enemyModel = GetComponent<EnemyModel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInteractionManager>(out PlayerInteractionManager player))
        {
            player.TakeDamage(_enemyModel.Damage);
        }
    }
}
