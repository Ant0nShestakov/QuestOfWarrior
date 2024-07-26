using UnityEngine;

[RequireComponent (typeof(InputController), typeof(Animator), typeof(InputController))]
public class PlayerMovemenManager : MonoBehaviour, IManager
{
    [Header("GroundCheck")]
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheckTransform;

    private InputController _inputController;

    #region movement stats
    private float _hInput;
    private float _vInput;
    private Vector3 _direction;
    #endregion

    private PlayerModel _playerModel;
    private StateSwitcher _stateSwitcher;
    private MovementSoundController _soundManager;
    private Animator _animator;

    public PlayerModel PlayerModel { get => _playerModel; }
    public StateSwitcher StateSwitcher { get => _stateSwitcher; }
    public CharacterController CharacterController { get => _playerModel.CharacterController; }
    public Animator Animator { get => _animator; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerModel = GetComponent<PlayerModel>();
        _inputController = GetComponent<InputController>();

        _soundManager = GetComponentInChildren<MovementSoundController>();

        WalkingState ws = new WalkingState();
        _stateSwitcher = new StateSwitcher(ws);
        ws.EnterState(this);
    }

    private void Update()
    {
        _playerModel.IsGrounded = Physics.CheckSphere(_groundCheckTransform.position, _radius, _groundLayer);

        if (PlayerModel.IsGrounded)
        {
            SetMoveDiraction();
            if (_inputController.JumpValue > 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, Vector3.down, out hit, Mathf.Infinity))
                    if (Vector3.Angle(hit.normal, Vector3.up) >= CharacterController.slopeLimit)
                        return;

                Jump();
            }

        }

        if (!PlayerModel.IsSwim)
            _direction.y -= PlayerModel.PlayerProperites.Gravity * Time.deltaTime;

        CharacterController.Move(_direction * Time.deltaTime);
        _stateSwitcher.UpdateState(this);

        PlayerModel.SavePosition = this.transform.position;

        _animator.SetFloat("hInput", _hInput, 0.1f, Time.deltaTime);
        _animator.SetFloat("vInput", _vInput, 0.1f, Time.deltaTime);
    }

    private void SetMoveDiraction()
    {
        _hInput = _inputController.MoveValue.x;
        _vInput = _inputController.MoveValue.y;
        Vector3 inputDiraction = new Vector3(_hInput, 0, _vInput);
        inputDiraction = transform.TransformDirection(inputDiraction);

        _direction = inputDiraction.normalized * PlayerModel.PlayerProperites.CurrentSpeed;
    }

    private void Jump()
    {
        if (!PlayerModel.IsAttack && !PlayerModel.IsSwim)
            _direction.y = PlayerModel.PlayerProperites.JumpForce;
    }

    public void SwitchState(IState state) =>
        _stateSwitcher.SwitchState(this, state);

    public void PlayWalkSound(int indexPan) 
    {
        if (!PlayerModel.IsAttack)
            _soundManager.PlayWalkSound(indexPan);
    }
}
