using UnityEngine;
using Zenject;

public class GameModeInstaller : MonoInstaller
{
    [Header("Player settings")]
    [SerializeField] private Transform _playerTransoform;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private bool _isSpawnToCameraLocation;

    [Header("Enemy settings")]
    [SerializeField] private EnemyStats _enemyStats;

    private void SpamAndBindPlayer()
    {
        //var player = Container.InstantiatePrefabForComponent<PlayerModel>(_playerPrefab);

        //if (_isSpawnToCameraLocation)
        //    player.transform.SetPositionAndRotation(SceneViewCameraSaver.CameraPosition, SceneViewCameraSaver.CameraRotation);

        //player.transform.SetPositionAndRotation(_playerTransoform.position, _playerTransoform.rotation);

        //Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(player).AsSingle().NonLazy();
    }

    private void BindScriptableObjects()
    {
        Container.Bind<EnemyStats>().FromInstance(_enemyStats);
    }

    public override void InstallBindings()
    {
        BindScriptableObjects();
        SpamAndBindPlayer();
    }


}