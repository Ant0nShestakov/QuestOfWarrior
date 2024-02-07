using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractionManager : MonoBehaviour
{
    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        PlayerModel = GetComponent<PlayerModel>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<DoorManager>(out DoorManager door))
        {
            if (Input.GetKey(KeyCode.E) && !PlayerModel.LockState)
                door.OpenDoor();
            return;
        }
    }

    public void TakeDamage(int Damage)
    {
        if (PlayerModel.GetDamage(Damage) <= 0 && !PlayerModel.LockState)
        {
            PlayerModel.SetCursorFreeState();
            SceneManager.LoadScene(2);
        }
    }
}
