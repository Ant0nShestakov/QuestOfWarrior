using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    private PlayerModel _playerModel;

    private void Start()
    {
        _playerModel = GetComponent<PlayerModel>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<EnemyManager>(out EnemyManager enemy) && !_playerModel.LockState)
            enemy.TakeDamage(_playerModel.Damage);
    }
}
