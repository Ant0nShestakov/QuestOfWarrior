using System.Collections;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour, IManager
{
    [SerializeField] private float RegenerationInSeconds;

    private PlayerAttackSoundController _soundManager;
    private StateSwitcher _stateSwitcher;
    private PlayerModel _playerModel;
    private CharacterController _characterController;
    private PlayerInteractionManager _interactionManager;
    private bool _isOnGround;

    public Animator Animator { get; private set; }
    public PlayerModel PlayerModel { get => _playerModel; }
    public StateSwitcher StateSwitcher { get => _stateSwitcher; }
    public CharacterController CharacterController { get => _characterController; }
    public bool IsOnGround { get => _isOnGround; }

    private void Start()
    {
        _stateSwitcher = new StateSwitcher(new IdleState());
        Animator = GetComponent<Animator>();
        _playerModel = GetComponent<PlayerModel>();
        _characterController = GetComponent<CharacterController>();
        _interactionManager = GetComponent<PlayerInteractionManager>();
        StartCoroutine(RegenarationStamina());
        _soundManager = GetComponentInChildren<PlayerAttackSoundController>();
    }

    private void Update()
    {
        _stateSwitcher.UpdateState(this);
    }

    private IEnumerator RegenarationStamina()
    {
        while (true)
        {
            if (!PlayerModel.LockState)
            {
                PlayerModel.RegenerationStamina();
                _interactionManager.UpdateUiInfo();
            }
            yield return new WaitForSecondsRealtime(RegenerationInSeconds);
        }
    }

    public void SwitchState(IState state) => _stateSwitcher.SwitchState(this, state);

    public void PlayAttackSound() => _soundManager.PlayRageSound();
}
