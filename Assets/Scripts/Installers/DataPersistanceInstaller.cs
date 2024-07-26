using UnityEngine;
using Zenject;

public class DataPersistanceInstaller : MonoInstaller
{
    [SerializeField] private DataPersistanceManager _prefab;

    public override void InstallBindings()
    {

        Container.Bind<DataPersistanceManager>().FromComponentInNewPrefab(_prefab).AsSingle();
    }
}
