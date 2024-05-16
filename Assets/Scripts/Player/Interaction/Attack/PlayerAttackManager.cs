using System.Collections;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour, IManager
{
    private PlayerAttackSoundController _soundManager;
    private StateSwitcher _stateSwitcher;
    private PlayerModel _playerModel;
    private CharacterController _characterController;
    private PlayerInteractionManager _interactionManager;

    public Animator Animator { get; private set; }
    public PlayerModel PlayerModel { get => _playerModel; }
    public StateSwitcher StateSwitcher { get => _stateSwitcher; }
    public CharacterController CharacterController { get => _characterController; }

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
        if (PlayerModel.LockState)
            return;
        _stateSwitcher.UpdateState(this);
    }

    private IEnumerator RegenarationStamina()
    {
        while (true)
        {
            if (!PlayerModel.LockState)
            {
                PlayerModel.RegenerationStamina();
                _interactionManager.UpdateInfoInUI();
            }
            yield return new WaitForSecondsRealtime(PlayerModel.PlayerProperites.TickRegenerationInSeconds);
        }
    }

    public void SwitchState(IState state) => _stateSwitcher.SwitchState(this, state);

    public void PlayAttackSound() => _soundManager.PlayRageSound();
}
