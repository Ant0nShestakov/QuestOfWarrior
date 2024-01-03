using UnityEngine;

public class CreateEnemyPool : MonoBehaviour
{
    [SerializeField] private EnemyManager _prefab;
    [SerializeField] private int _count;
    [SerializeField] private bool _isEnded = false;

    //свойство на чтение пула с врагами
    public ObjectPool<EnemyManager> ObjectPoolEnemy { get; private set; } = null!;

    private void Start()
    {
        ObjectPoolEnemy = new ObjectPool<EnemyManager>(_count, _prefab, _isEnded);
    }
}
