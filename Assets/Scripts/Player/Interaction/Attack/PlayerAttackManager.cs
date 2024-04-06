using System.Collections;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour, IManager
{
    [SerializeField] private float RegenerationInSeconds;

    private PlayerAttackSoundController _soundManager;
    private StateSwitcher _stateSwitcher;
    private PlayerModel _playerModel;
    private CharacterController _characterController;
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
        StartCoroutine(RegenarationStamina());
        _soundManager = GetComponentInChildren<PlayerAttackSoundController>();
    }

    // Update is called once per frame
    private void Update()
    {
        _stateSwitcher.UpdateState(this);
    }

    private IEnumerator RegenarationStamina()
    {
        while (true)
        {
            PlayerModel.RegenerationStamina();
            yield return new WaitForSecondsRealtime(RegenerationInSeconds);
        }
    }

    public void SwitchState(IState state) => _stateSwitcher.SwitchState(this, state);

    public void PlayAttackSound() => _soundManager.PlayRageSound();
}
