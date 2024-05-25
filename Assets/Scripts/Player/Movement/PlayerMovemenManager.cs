using System.Collections;
using UnityEngine;

public class PlayerMovemenManager : MonoBehaviour, IManager
{
    #region movement stats
    private float _hInput;
    private float _vInput;
    private Vector3 _direction;
    #endregion

    [SerializeField] private float _timeBeforeFall;

    private PlayerModel _playerModel;
    private StateSwitcher _stateSwitcher;
    private PlayerMovementSoundController _soundManager;
    private Animator _animator;
    private CharacterController _characterController;

    public PlayerModel PlayerModel { get => _playerModel; }
    public StateSwitcher StateSwitcher { get => _stateSwitcher; }
    public CharacterController CharacterController { get => _characterController; }
    public Animator Animator { get => _animator; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _playerModel = GetComponent<PlayerModel>();
        _soundManager = GetComponentInChildren<PlayerMovementSoundController>();
        WalkingState ws = new WalkingState();
        _stateSwitcher = new StateSwitcher(ws);
        ws.EnterState(this);
    }

    private void Update()
    {
        if (PlayerModel.IsOnGround)
        {
            SetMoveDiraction();
            if (Input.GetKey(KeyCode.Space))
            {
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, Vector3.down, out hit, Mathf.Infinity))
                {
                    if (Vector3.Angle(hit.normal, Vector3.up) >= _characterController.slopeLimit)
                        return;
                    Jump();
                }
            }

        }

        if (!PlayerModel.IsSwim)
            _direction.y -= PlayerModel.PlayerProperites.Gravity * Time.deltaTime;

        _characterController.Move(_direction * Time.deltaTime);
        _stateSwitcher.UpdateState(this);

        PlayerModel.SavePosition = this.transform.position;

        _animator.SetFloat("hInput", _hInput);
        _animator.SetFloat("vInput", _vInput);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.layer == LayerMask.NameToLayer("GroundRock"))
        {
            PlayerModel.IsOnGround = true;
            PlayerModel.IsFreeFly = false;
            return;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            if(_animator.applyRootMotion)
                _animator.applyRootMotion = false;
            PlayerModel.IsOnGround = false;
            PlayerModel.IsFreeFly = false;
            PlayerModel.IsSwim = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.layer == LayerMask.NameToLayer("GroundRock"))
        {
            PlayerModel.IsOnGround = false;
            StartCoroutine(FreeFlyCorroutine());
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            _animator.applyRootMotion = true;
            PlayerModel.IsOnGround = true;
            PlayerModel.IsSwim = false;
        }
    }

    private IEnumerator FreeFlyCorroutine()
    {
        yield return new WaitForSeconds(_timeBeforeFall);
        if (!PlayerModel.IsOnGround)
            PlayerModel.IsFreeFly = true;
        else
            PlayerModel.IsFreeFly = false;
    }

    private void SetMoveDiraction()
    {
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");
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
