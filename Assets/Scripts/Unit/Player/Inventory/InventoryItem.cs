using System;
using UnityEngine;

public class InventoryItem : MonoBehaviour, IPooledObject<InventoryItem>
{
    private UnitModel _playerModel;

    public event Action<InventoryItem> PushEvent;

    private void OnEnable()
    {
        //_playerModel = Singleton<UnitModel>.Instance;
    }

    private void OnDisable()
    {
        PushEvent = null;
    }

    public void UseItem(Item item)
    {
        //if (item.Type == TypeItem.health)
        //{
        //    _playerModel.HealthSelf(item.Value);
        //    _playerModel.InventoryManager.Remove(item);
        //}
        //else if (item.Type == TypeItem.energy)
        //{
        //    _playerModel.RegenerationStamina(item.Value);
        //    _playerModel.InventoryManager.Remove(item);
        //}
    }

    public void Pushed() => PushEvent?.Invoke(this);
}
