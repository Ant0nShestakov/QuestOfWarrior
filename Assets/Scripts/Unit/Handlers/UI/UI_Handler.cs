using UnityEngine;

public sealed class UI_Handler : IHandler
{
    private readonly InventoryManager _inventory;
    private readonly GameObject _skillBuilder;
    private readonly InputController _inputManager;
    private readonly UnitModel _unit;

    public UI_Handler(InventoryManager inventoryView, GameObject skillBuilder, UnitModel unit)
    {
        _inventory = inventoryView;
        _unit = unit;
        _skillBuilder = skillBuilder;
        _inputManager = inventoryView.GetComponentInParent<InputController>();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (!_inventory.gameObject.activeSelf)
            {
                _inventory.gameObject.SetActive(true);
                _inputManager.SetCursorFreeState();
                _unit.InventoryManager.ShowInventory();
                return;
            }

            _inventory.gameObject.SetActive(false);
            _inputManager.SetCursorLockState();
            _unit.InventoryManager.CloseInventory();
            return;
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            if (!_skillBuilder.activeSelf)
            {
                _skillBuilder.SetActive(true);
                _inputManager.SetCursorFreeState();
                return;
            }

            _skillBuilder.SetActive(false);
            _inputManager.SetCursorLockState();
            return;
        }
    }
}