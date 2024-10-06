using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private int _count;
    [SerializeField] private bool _isEnded;
    [SerializeField] private EnemyManager _prefab;
    [SerializeField] private EnemyStats _enemyStats;

    public override void InstallBindings()
    {
        Container.Bind<EnemyStats>().FromInstance(_enemyStats);
        Container.Bind<IObjectPool<EnemyManager>>().To<ObjectPool<EnemyManager>>().AsSingle().WithArguments(_count, _prefab, _isEnded).NonLazy();
    }
}
