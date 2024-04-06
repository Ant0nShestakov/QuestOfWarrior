using UnityEngine;

public class PlayerMovemenManager : MonoBehaviour, IManager
{
    private float _hInput;
    private float _vInput;

    private Animator _animator;
    private PlayerModel _playerModel;
    private CharacterController _characterController;
    private bool _isOnGround;

    private StateSwitcher _stateSwitcher;
    private PlayerMovementSoundController _soundManager;
    private Vector3 _direction;

    public bool IsOnGround { get => _isOnGround; }
    public PlayerModel PlayerModel { get => _playerModel; }
    public CharacterController CharacterController { get => _characterController;}
    public Animator Animator { get => _animator; }
    public StateSwitcher StateSwitcher { get => _stateSwitcher; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _playerModel = GetComponent<PlayerModel>();
        _soundManager = GetComponentInChildren<PlayerMovementSoundController>();
        _stateSwitcher = new StateSwitcher(new WalkingState());
        _isOnGround = true;
    }

    private void Update()
    {
        if (PlayerModel.LockState)
            return;

        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");
        _direction = this.transform.forward * _vInput + this.transform.right * _hInput;
        _characterController.Move(_direction.normalized * PlayerModel.Speed * Time.deltaTime);
        _stateSwitcher.UpdateState(this);
        _animator.SetFloat("hInput", _hInput);
        _animator.SetFloat("vInput", _vInput);
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsOnGround)
            return;

        if (other.gameObject.layer == 8)
            _isOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
            _isOnGround = false;
    }

    public void SwitchState(IState state) =>
        _stateSwitcher.SwitchState(this, state);

    public void PlayWalkSound(int indexPan) => 
        _soundManager.PlayWalkSound(indexPan);
}
