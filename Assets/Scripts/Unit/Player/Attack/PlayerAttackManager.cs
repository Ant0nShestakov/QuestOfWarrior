using System.Collections;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour, IManager
{
    private PlayerAttackSoundController _soundManager;
    private StateSwitcher _stateSwitcher;
    private PlayerModel _playerModel;

    public Animator Animator { get; private set; }
    public PlayerModel PlayerModel { get => _playerModel; }
    public StateSwitcher StateSwitcher { get => _stateSwitcher; }

    private void Start()
    {
        _stateSwitcher = new StateSwitcher(new IdleState());
        Animator = GetComponent<Animator>();
        _playerModel = GetComponent<PlayerModel>();
        _soundManager = GetComponentInChildren<PlayerAttackSoundController>();

        StartCoroutine(RegenarationStamina());
    }

    private void Update()
    {
        if (PlayerModel.IsLocked)
            return;
        _stateSwitcher.UpdateState(this);
    }

    private IEnumerator RegenarationStamina()
    {
        while (true)
        {
            if (!PlayerModel.IsLocked)
                PlayerModel.RegenerationStamina();
            yield return new WaitForSecondsRealtime(PlayerModel.PlayerProperites.TickRegenerationInSeconds);
        }
    }

    public void SwitchState(IState state) => _stateSwitcher.SwitchState(this, state);

    public void PlayAttackSound() => _soundManager.PlayRageSound();
}
