using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _skillBuilder;

    private event Action _healthAndStaminaEvent;
    //private InventoryManager _inventoryManager;
    private HealthBar _healthBar;

    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        PlayerModel = GetComponent<PlayerModel>();
        //_inventoryManager = GetComponent<InventoryManager>();
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
                if (!PlayerModel.IsNotLocked)
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
                if (!PlayerModel.IsNotLocked)
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
            if (Input.GetKey(KeyCode.E) && !PlayerModel.IsNotLocked)
                door.OpenDoor();
            return;
        }
        if(other.TryGetComponent<ChestManager>(out ChestManager chest))
        {
            if (Input.GetKey(KeyCode.E) && !PlayerModel.IsNotLocked)
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
            if (Input.GetKey(KeyCode.E) && !PlayerModel.IsNotLocked)
                lvl.LoadSceneByDefaultIndex();
            return;
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
