using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractionManager : MonoBehaviour
{
    private InteractionState _curentState;

    public AttackState AttackState = new AttackState();
    public BlockState BlockState = new BlockState();
    public IdleState IdleState = new IdleState();

    public Animator Animator { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        PlayerModel = GetComponent<PlayerModel>();
        _curentState = IdleState;
    }

    // Update is called once per frame
    private void Update()
    {
        _curentState.UpdateState(this);
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

    public void SwitchState(InteractionState state)
    {
        _curentState = state;
        _curentState.EnterState(this);
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
