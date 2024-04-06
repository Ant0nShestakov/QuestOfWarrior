using System.Collections;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [SerializeField] private float RegenerationInSeconds;

    private PlayerAttackSoundController _soundManager;
    private AttackStateSwitcher _attackStateSwitcher;

    public Animator Animator { get; private set; }
    public PlayerModel PlayerModel { get; private set; }
    public AttackStateSwitcher AttackStateSwitcher { get => _attackStateSwitcher; }

    private void Start()
    {
        _attackStateSwitcher = new AttackStateSwitcher();
        Animator = GetComponent<Animator>();
        PlayerModel = GetComponent<PlayerModel>();
        StartCoroutine(RegenarationStamina());
        _soundManager = GetComponentInChildren<PlayerAttackSoundController>();
    }

    // Update is called once per frame
    private void Update()
    {
        _attackStateSwitcher.UpdateState(this);
    }

    private IEnumerator RegenarationStamina()
    {
        while (true)
        {
            PlayerModel.RegenerationStamina();
            yield return new WaitForSecondsRealtime(RegenerationInSeconds);
        }
    }

    public void SwitchState(AttackState state) => _attackStateSwitcher.SwitchState(this, state);

    public void PlayAttackSound() => _soundManager.PlayRageSound();
}
