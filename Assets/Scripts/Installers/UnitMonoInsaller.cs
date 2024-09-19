using UnityEngine;
using Zenject;

[RequireComponent(typeof(Controller), typeof(UnitView), typeof(InventoryManager))]
public sealed class UnitMonoInsaller : MonoInstaller
{
    [SerializeField] private Transform _cameraTransform;

    [Header("Unit")]
    [SerializeField] private PlayerStats _unitStats;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private UnitController _unitController;

    private void BindHandlers()
    {
        Container.Bind<IHandler>().To<MovementHandler>().AsCached();
        Container.Bind<IHandler>().To<AimHandler>().AsCached().WithArguments(_cameraTransform);
        Container.Bind<IHandler>().To<UI_Handler>().AsCached();
    }
    private void BindUnitModel()
    {
        Container.BindInstance<PlayerStats>(_unitStats);

        Container.Bind<UnitModel>()
            .AsSingle()
            .NonLazy();
    }
   
    private void BindFSM()
    {
        Container.Bind<IActionStateVisitor>().To<MovementFSMVisitor>().AsCached();
        Container.Bind<IFSM>().To<MovementFSM>().AsCached().WithArguments(GetComponent<UnitView>());
        Container.Bind<IFSM>().To<AttackFSM>().AsCached().WithArguments(GetComponent<UnitView>());
    }

    public override void InstallBindings()
    {
        Container.Bind<InventoryManager>().FromInstance(_inventoryManager).AsSingle().NonLazy();

        BindUnitModel();

        Container.Bind<Controller>().To<UnitController>().FromInstance(_unitController).AsSingle().NonLazy();

        BindHandlers();
        BindFSM();
    }
}