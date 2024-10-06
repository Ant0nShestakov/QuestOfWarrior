using UnityEngine;

public sealed class WeaponHandler : IHandler
{
    private readonly UnitModel _unitModel;

    private readonly float _maxStamina;

    public WeaponHandler(UnitModel model)
    {
        _maxStamina = model.PlayerProperites.MaxStamina;
        _unitModel = model;
    }

    public void Update()
    {
        if(_unitModel.PlayerProperites.CurrentStamina < _maxStamina)
        {
            _unitModel.PlayerProperites.RegenerationStamina();
            _unitModel.UpdateManaInfo();
        }
    }
}
