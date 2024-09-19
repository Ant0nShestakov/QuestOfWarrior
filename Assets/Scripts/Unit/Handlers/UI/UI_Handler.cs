using UnityEngine;

public sealed class UI_Handler : IHandler
{
    private readonly InventoryManager _inventory;
    private readonly GameObject _skillBuilder;
    private readonly InputController _inputManager;
    private readonly UnitModel _unit;

    public UI_Handler(/*InventoryManager inventoryView, GameObject skillBuilder,*/ UnitModel unit)
    {
        //_inventory = inventoryView;
        _unit = unit;
        //_skillBuilder = skillBuilder;
        //_inputManager = inventoryView.GetComponentInParent<InputController>();
    }

    public void Update()
    {
        //if (_inputManager.ShowInventoryValue > 0)
        //{
        //    if (!_inventory.gameObject.activeSelf)
        //    {
        //        if (!_unit.IsLocked)
        //            return;
                
        //        _inventory.gameObject.SetActive(true);
        //        _unit.SetCursorFreeState();
        //        _unit.InventoryManager.ShowInventory();
        //        return;
        //    }

        //    _inventory.gameObject.SetActive(false);
        //    _unit.SetCursorLockState();
        //    _unit.InventoryManager.CloseInventory();
        //    return;
        //}

        //if (_inputManager.ShowSkillBuildValue > 0)
        //{
        //    if (!_skillBuilder.activeSelf)
        //    {
        //        if (!_unit.IsLocked)
        //            return;
                
        //        _skillBuilder.SetActive(true);
        //        _unit.SetCursorFreeState();
        //        return;
        //    }

        //    _skillBuilder.SetActive(false);
        //    _unit.SetCursorLockState();
        //    return;
        //}
    }
}