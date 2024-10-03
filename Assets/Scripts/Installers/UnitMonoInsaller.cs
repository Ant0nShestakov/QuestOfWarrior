using UnityEngine;
using Zenject;

[RequireComponent(typeof(Controller), typeof(UnitView))]
public sealed class UnitMonoInsaller : MonoInstaller
{
    [SerializeField] private Transform _cameraTransform;

    [Header("Unit")]
    [SerializeField] private PlayerStats _unitStats;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private UnitController _unitController;
    //!
    [SerializeField] private GameObject _skillBuilder;

    private void BindHandlers()
    {
        Container.Bind<IHandler>().To<AimHandler>().AsCached().WithArguments(_cameraTransform);
        Container.Bind<IHandler>().To<MovementHandler>().AsCached();
        Container.Bind<IHandler>().To<UI_Handler>().AsCached().WithArguments(_skillBuilder);
        Container.Bind<IHandler>().To<WeaponHandler>().AsCached();
    }
    private void BindUnitModel()
    {
        Container.Bind<InventoryManager>().FromInstance(_inventoryManager).AsSingle().NonLazy();

        Container.BindInstance<PlayerStats>(_unitStats);

        Container.Bind<UnitModel>().AsSingle().NonLazy();
    }
   
    private void BindFSM()
    {
        Container.Bind<IActionStateVisitor>().To<MovementFSMVisitor>().AsCached();
        Container.Bind<IActionStateVisitor>().To<AttackFSMVisitor>().AsCached();
        Container.Bind<IFSM>().To<MovementFSM>().AsCached().WithArguments(GetComponent<UnitView>());
        Container.Bind<IFSM>().To<AttackFSM>().AsCached().WithArguments(GetComponent<UnitView>());
    }

    public override void InstallBindings()
    {
        Container.Bind<PhysicsController>().FromInstance(GetComponent<PhysicsController>());

        BindUnitModel();

        Container.Bind<Controller>().To<UnitController>().FromInstance(_unitController).AsSingle().NonLazy();

        BindHandlers();
        BindFSM();
    }
}