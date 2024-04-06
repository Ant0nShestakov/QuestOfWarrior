using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private PlayerModel _playerModel;

    private void Start() => _playerModel = GetComponent<PlayerModel>();
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<EnemyManager>(out EnemyManager enemy))
            enemy.TakeDamage(_playerModel.Damage);
    }
}
