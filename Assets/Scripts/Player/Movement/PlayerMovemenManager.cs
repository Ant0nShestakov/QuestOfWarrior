using UnityEngine;

public class PlayerMovemenManager : MonoBehaviour
{
    private float _hInput;
    private float _vInput;

    private Animator _animator;
    private CharacterController _characterController;

    private MovenetState _state;
    private Vector3 _direction;

    private PlayerMovementSoundController _soundManager;

    public RunningState RuningState = new RunningState();
    public WalkingState WalkingState = new WalkingState();
    public JumpingState JumpingState = new JumpingState();
    public FreeFlyState FreeFlyState = new FreeFlyState();
    public LandingState LandingState = new LandingState();

    [field: SerializeField] public float JumpForce { get; private set; }
    public PlayerModel PlayerModel { get; private set; }

    [field: SerializeField] public bool isOnGround { get; private set; }
    public CharacterController CharacterController { get => _characterController;}
    public Animator Animator { get => _animator; }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        PlayerModel = GetComponent<PlayerModel>();
        _soundManager = GetComponentInChildren<PlayerMovementSoundController>();
        _state = WalkingState;
        isOnGround = true;
    }

    void Update()
    {
        if (!PlayerModel.LockState)
        {
            _hInput = Input.GetAxis("Horizontal");
            _vInput = Input.GetAxis("Vertical");
            _direction = this.transform.forward * _vInput + this.transform.right * _hInput;
            _characterController.Move(_direction.normalized * PlayerModel.Speed * Time.deltaTime);
            _state.UpdateState(this);
            _animator.SetFloat("hInput", _hInput);
            _animator.SetFloat("vInput", _vInput);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isOnGround)
            return;

        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 )
            isOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
            isOnGround = false;
    }

    public void SwitchState(MovenetState state)
    {
        _state = state;
        _state.EnterState(this);
    }

    public void PlayWalkSound(int indexPan) => _soundManager.PlayWalkSound(indexPan);
}
