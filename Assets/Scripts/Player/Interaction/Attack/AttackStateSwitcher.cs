public class AttackStateSwitcher
{
    private AttackState _currentState;

    public AutoAttackState AutoAttackState { get; private set; }
    public BlockState BlockState { get; private set; }
    public IdleState IdleState { get; private set; }
    public SpecialFastAttackState SpecialFastAttackState { get; private set; }
    public SpecialStrongAttackState SpecialStrongAttackState { get; private set; }

    public AttackStateSwitcher()
    {
        AutoAttackState = new AutoAttackState();
        BlockState = new BlockState();
        IdleState = new IdleState();
        SpecialFastAttackState = new SpecialFastAttackState();
        SpecialStrongAttackState = new SpecialStrongAttackState();

        _currentState = IdleState;
    }
    
    public void UpdateState(PlayerAttackManager attack) =>
        _currentState.UpdateState(attack);

    public void SwitchState(PlayerAttackManager attack, AttackState state)
    {
        _currentState = state;
        _currentState.EnterState(attack);
    }
}