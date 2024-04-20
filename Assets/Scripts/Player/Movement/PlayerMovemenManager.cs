using UnityEngine;

public class PlayerMovemenManager : MonoBehaviour, IManager
{
    #region movement stats
    private float _hInput;
    private float _vInput;
    private bool _isOnGround;
    private Vector3 _direction;
    #endregion

    private PlayerModel _playerModel;
    private StateSwitcher _stateSwitcher;
    private PlayerMovementSoundController _soundManager;

    private Animator _animator;
    private CharacterController _characterController;

    public bool IsOnGround { get => _isOnGround; }
    public PlayerModel PlayerModel { get => _playerModel; }
    public StateSwitcher StateSwitcher { get => _stateSwitcher; }

    public CharacterController CharacterController { get => _characterController;}
    public Animator Animator { get => _animator; }


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _playerModel = GetComponent<PlayerModel>();
        _soundManager = GetComponentInChildren<PlayerMovementSoundController>();
        _stateSwitcher = new StateSwitcher(new WalkingState());
        //_isOnGround = true;
    }

    private void Update()
    {
        if (PlayerModel.LockState)
            return;

        if(IsOnGround) 
        {
            SetMoveDiraction();
            if (Input.GetKey(KeyCode.Space))
                Jump();
        }

        _direction.y -= PlayerModel.Gravity * Time.deltaTime;
        _characterController.Move(_direction * Time.deltaTime);

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

    private void SetMoveDiraction()
    {
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");
        Vector3 inputDiraction = new Vector3(_hInput, 0, _vInput);
        inputDiraction = transform.TransformDirection(inputDiraction);
        _direction = inputDiraction.normalized * PlayerModel.Speed;
    }

    private void Jump() => _direction.y = PlayerModel.JumpForce;

    public void SwitchState(IState state) =>
        _stateSwitcher.SwitchState(this, state);

    public void PlayWalkSound(int indexPan) => 
        _soundManager.PlayWalkSound(indexPan);
}
