using System;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _skillBuilder;

    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        PlayerModel = GetComponent<PlayerModel>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_inventory.activeSelf)
            {
                if (!PlayerModel.IsLocked)
                {
                    _inventory.SetActive(true);
                    PlayerModel.SetCursorFreeState();
                    PlayerModel.InventoryManager.ShowInventory();
                }
                return;
            }

            _inventory.SetActive(false);
            PlayerModel.SetCursorLockState();
            PlayerModel.InventoryManager.CloseInventory();
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            if (!_skillBuilder.activeSelf)
            {
                if (!PlayerModel.IsLocked)
                {
                    _skillBuilder.SetActive(true);
                    PlayerModel.SetCursorFreeState();
                }
                return;
            }

            _skillBuilder.SetActive(false);
            PlayerModel.SetCursorLockState();
            return;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<DoorManager>(out DoorManager door))
        {
            if (Input.GetKey(KeyCode.E) && !PlayerModel.IsLocked)
                door.OpenDoor();
            return;
        }
        if(other.TryGetComponent<ChestManager>(out ChestManager chest))
        {
            if (Input.GetKey(KeyCode.E) && !PlayerModel.IsLocked)
            {
                Item item;
                if(chest.TryGetItems(out item))
                    PlayerModel.InventoryManager.Add(item);
                return;
            }
            return;
        }
        if (other.TryGetComponent<LoadLvL>(out LoadLvL lvl))
        {
            if (Input.GetKey(KeyCode.E) && !PlayerModel.IsLocked)
                lvl.LoadSceneByDefaultIndex();
            return;
        }
    }

}
