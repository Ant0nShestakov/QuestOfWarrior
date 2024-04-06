using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private EnemyManager _prefab;
    [SerializeField] private int _count;
    [SerializeField] private bool _isEnded = false;

    public ObjectPool<EnemyManager> ObjectPoolEnemy { get; private set; } = null!;

    private void Start()
    {
        ObjectPoolEnemy = new ObjectPool<EnemyManager>(_count, _prefab, _isEnded);
    }
}
