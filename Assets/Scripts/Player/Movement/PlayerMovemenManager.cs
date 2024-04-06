using UnityEngine;

public class PlayerMovemenManager : MonoBehaviour
{
    private float _hInput;
    private float _vInput;

    private Animator _animator;
    private CharacterController _characterController;

    private MovementStateSwitcher _movementStateSwitcher;
    private PlayerMovementSoundController _soundManager;
    private Vector3 _direction;

    public bool isOnGround { get; private set; }
    public PlayerModel PlayerModel { get; private set; }
    public CharacterController CharacterController { get => _characterController;}
    public Animator Animator { get => _animator; }
    public MovementStateSwitcher RealMovementState { get => _movementStateSwitcher; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        PlayerModel = GetComponent<PlayerModel>();
        _soundManager = GetComponentInChildren<PlayerMovementSoundController>();
        _movementStateSwitcher = new MovementStateSwitcher();
        isOnGround = true;
    }

    private void Update()
    {
        if (PlayerModel.LockState)
            return;

        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");
        _direction = this.transform.forward * _vInput + this.transform.right * _hInput;
        _characterController.Move(_direction.normalized * PlayerModel.Speed * Time.deltaTime);
        _movementStateSwitcher.UpdateState(this);
        _animator.SetFloat("hInput", _hInput);
        _animator.SetFloat("vInput", _vInput);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isOnGround)
            return;

        if (other.gameObject.layer == 8)
            isOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
            isOnGround = false;
    }

    public void SwitchState(MovementState state) =>
        _movementStateSwitcher.SwitchState(this, state);

    public void PlayWalkSound(int indexPan) => 
        _soundManager.PlayWalkSound(indexPan);
}
