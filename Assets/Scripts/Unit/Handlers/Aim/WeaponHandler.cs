//using UnityEngine;

//public sealed class WeaponHandler //: IHandler
//{
//    private readonly Transform _recoilTargetTransform;
//    private readonly InputManager _inputManager;


//    public WeaponHandler(Transform recoilTargetTransform, Controller controller)
//    {
//        _recoilTargetTransform = recoilTargetTransform;
//        _inputManager = controller.GetComponent<InputManager>();
//    }

//    public void Update()
//    {
//        if (_inputManager.ShootValue > 0)
//            _currentWeapon?.Shoot();
//        else if (_inputManager.ReloadValue > 0)
//            _currentWeapon?.Reload();
//    }

//    public void SetupWeapon(AbstractWeapon weapon)
//    {
//        _currentWeapon = weapon;
//        _currentWeapon.SetRecoilTarget();
//    }
//}
