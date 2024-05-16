using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;

    private event Action _healthAndStaminaEvent;
    private InventoryManager _inventoryManager;
    private HealthBar _healthBar;

    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        PlayerModel = GetComponent<PlayerModel>();
        _inventoryManager = GetComponent<InventoryManager>();
    }

    private void OnEnable()
    {
        _healthBar = GetComponentInChildren<HealthBar>();
        _healthAndStaminaEvent += _healthBar.UpdateInfo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_inventory.activeSelf)
            {
                _inventory.SetActive(true);
                PlayerModel.SetCursorFreeState();
                _inventoryManager.ShowInventory();
                return;
            }

            _inventory.SetActive(false);
            PlayerModel.SetCursorLockState();
            _inventoryManager.CloseInventory();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<DoorManager>(out DoorManager door))
        {
            if (Input.GetKey(KeyCode.E) && !PlayerModel.LockState)
                door.OpenDoor();
            return;
        }
        if(other.TryGetComponent<ChestManager>(out ChestManager chest))
        {
            if (Input.GetKey(KeyCode.E) && !PlayerModel.LockState)
            {
                Item item;
                if(chest.TryGetItems(out item))
                    _inventoryManager.Add(item);
            }
        }
    }

    private void OnDisable()
    {
        _healthAndStaminaEvent -= _healthBar.UpdateInfo;        
    }

    public void UpdateInfoInUI()
    {
        _healthAndStaminaEvent?.Invoke();
    }

    public void TakeDamage(int Damage)
    {
        if (PlayerModel.GetDamage(Damage) <= 0)
        {
            PlayerModel.SetCursorFreeState();
            SceneManager.LoadScene(2);
        }

        UpdateInfoInUI();
    }
}
