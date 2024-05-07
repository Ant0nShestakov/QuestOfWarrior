using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    private PlayerModel _playerModel;
    private InventoryManager _inventoryManager;

    private void OnEnable()
    {
        _playerModel = Singelton<PlayerModel>.Instance;
        _inventoryManager = Singelton<InventoryManager>.Instance;
    }

    public void UseItem(Item item)
    {
        if (item.Type == TypeItem.health)
        {
            _playerModel.HelthSelf(item.Value);
            _inventoryManager.Remove(item);
        }
        else if (item.Type == TypeItem.energy)
        {
            _playerModel.EnergyRegen(item.Value);
            _inventoryManager.Remove(item);
        }
    }
}
