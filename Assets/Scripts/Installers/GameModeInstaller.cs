using UnityEngine;
using Zenject;

public class GameModeInstaller : MonoInstaller
{
    [SerializeField] private PlayerModel _playerPrefab;
    [SerializeField] private Transform _playerPosition;

    public override void InstallBindings()
    {
        var player = Container.InstantiatePrefabForComponent<PlayerModel>(_playerPrefab, _playerPosition);

        Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(player).AsSingle().NonLazy();
    }
}