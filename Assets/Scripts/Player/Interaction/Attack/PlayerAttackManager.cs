using System.Collections;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [SerializeField] private float RegenerationInSeconds;
    private AttackState _curentAttackState;
    private PlayerAttackSoundsManager _soundManager;

    public AutoAttackState AttackState = new AutoAttackState();
    public BlockState BlockState = new BlockState();
    public IdleState IdleState = new IdleState();
    public SpecialStrongAttack SpecialStrongAttackState = new SpecialStrongAttack(); 
    public SpecialFastAttack SpecialFastAttackState = new SpecialFastAttack();

    public Animator Animator { get; private set; }
    //public CharacterController CharacterController { get; private set; }
    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        _curentAttackState = IdleState;
        Animator = GetComponent<Animator>();
        PlayerModel = GetComponent<PlayerModel>();
        StartCoroutine(RegenarationStamina());
        _soundManager = GetComponentInChildren<PlayerAttackSoundsManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        _curentAttackState.UpdateState(this);
    }

    private IEnumerator RegenarationStamina()
    {
        while (true)
        {
            PlayerModel.RegenerationStamina();
            yield return new WaitForSecondsRealtime(RegenerationInSeconds);
        }
    }

    public void SwitchState(AttackState state)
    {
        _curentAttackState = state;
        _curentAttackState.EnterState(this);
    }

    public void PlayAttackSound() 
    {
        _soundManager.PlayRageSound();
    }
}
