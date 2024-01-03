using UnityEngine;

public class SpamerController : MonoBehaviour
{
    [SerializeField] private Transform _spamerTransform;
    [SerializeField] private CreateEnemyPool _enemyPool;
    [SerializeField] private int _enemyCount;
    [SerializeField] float _xSpread;
    [SerializeField] float _zSpread;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerInteractionManager _))
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                Vector3 spamPosition = new Vector3(_spamerTransform.position.x +_xSpread,
                    _spamerTransform.position.y,_spamerTransform.position.z + _zSpread);
                if (_enemyPool.ObjectPoolEnemy.TryGetObject(out EnemyManager enemy, spamPosition))
                {
                    Debug.Log(enemy.transform.position);
                }
                _xSpread += 1;
                _zSpread += 1;
            }
            gameObject.SetActive(false);
        }
    }
}
