using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    private AttackState _curentAttackState;

    public AutoAttackState AttackState = new AutoAttackState();
    public BlockState BlockState = new BlockState();
    public IdleState IdleState = new IdleState();
    public SpecialStrongAttack SpecialAttackState = new SpecialStrongAttack(); 
    public SpecialFastAttack SpecialFastAttackState = new SpecialFastAttack();

    public Animator Animator { get; private set; }
    //public CharacterController CharacterController { get; private set; }
    public PlayerModel PlayerModel { get; private set; }

    private void Start()
    {
        _curentAttackState = IdleState;
        Animator = GetComponent<Animator>();
        PlayerModel = GetComponent<PlayerModel>();
    }

    // Update is called once per frame
    private void Update()
    {
        _curentAttackState.UpdateState(this);
    }

    public void SwitchState(AttackState state)
    {
        _curentAttackState = state;
        _curentAttackState.EnterState(this);
    }
}
