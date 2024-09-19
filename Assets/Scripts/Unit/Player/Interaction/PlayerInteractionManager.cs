using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    //[SerializeField] private float _interactionDistance;

    //[SerializeField] private GameObject _inventory;
    //[SerializeField] private GameObject _skillBuilder;

    //private IUIVisitor _playerUIManger;

    //public PlayerModel PlayerModel { get; private set; }

    //private void Start()
    //{
    //    PlayerModel = GetComponent<PlayerModel>();
    //    _playerUIManger = GetComponent<PlayerUIManger>();
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        if (!_inventory.activeSelf)
    //        {
    //            if (!PlayerModel.IsLocked)
    //            {
    //                _inventory.SetActive(true);
    //                PlayerModel.SetCursorFreeState();
    //                PlayerModel.InventoryManager.ShowInventory();
    //            }
    //            return;
    //        }

    //        _inventory.SetActive(false);
    //        PlayerModel.SetCursorLockState();
    //        PlayerModel.InventoryManager.CloseInventory();
    //        return;
    //    }
        
    //    if(Input.GetKeyDown(KeyCode.K))
    //    {
    //        if (!_skillBuilder.activeSelf)
    //        {
    //            if (!PlayerModel.IsLocked)
    //            {
    //                _skillBuilder.SetActive(true);
    //                PlayerModel.SetCursorFreeState();
    //            }
    //            return;
    //        }

    //        _skillBuilder.SetActive(false);
    //        PlayerModel.SetCursorLockState();
    //        return;
    //    }

    //    if (Input.GetKeyDown(KeyCode.E) && !PlayerModel.IsLocked)
    //    {

    //        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _interactionDistance))
    //        {
    //            if (hit.collider.TryGetComponent<DoorManager>(out DoorManager door))
    //                door.OpenDoor();
    //            else if (hit.collider.TryGetComponent<ChestManager>(out ChestManager chest))
    //            {
    //                Item item;
    //                if (chest.TryGetItems(out item))
    //                    PlayerModel.InventoryManager.Add(item);
    //            }
    //            else if (hit.collider.TryGetComponent<LoadLvL>(out LoadLvL lvl))
    //                lvl.LoadSceneByDefaultIndex();
    //        }
    //        return;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent<DoorManager>(out DoorManager door))
    //        _playerUIManger.Visit(door);
    //    else if(other.TryGetComponent<ChestManager>(out ChestManager chest))
    //        _playerUIManger.Visit(chest);
    //    else if(other.TryGetComponent<LoadLvL>(out LoadLvL lvl))
    //        _playerUIManger.Visit(lvl);
    //}

    //private void OnTriggerExit(Collider other) 
    //{
    //    _playerUIManger.Visit();
    //}
}
