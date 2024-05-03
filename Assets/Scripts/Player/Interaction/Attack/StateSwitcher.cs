using System;

public class StateSwitcher
{
    private IState _currentState;

    public Lazy<AutoAttackState> AutoAttackState { get; private set; } 
    public Lazy<BlockState> BlockState { get; private set; }
    public Lazy<IdleState> IdleState { get; private set; }
    public Lazy<SpecialFastAttackState> SpecialFastAttackState { get; private set; }
    public Lazy<SpecialStrongAttackState> SpecialStrongAttackState { get; private set; }
    public Lazy<SpecialStrongAttackWithJump> SpecialStrongAttackWithJump { get; private set; }
    public Lazy<WalkingState> WalkingState { get; private set; }
    public Lazy<RunningState> RunningState { get; private set; }
    public Lazy<FreeFlyState> FreeFlyState { get; private set; }

    public IState Current { get => _currentState; }

    public StateSwitcher(IState state)
    {
        AutoAttackState = new();
        BlockState = new();
        IdleState = new();
        SpecialFastAttackState = new();
        SpecialStrongAttackState = new();
        SpecialStrongAttackWithJump = new();

        WalkingState = new();
        RunningState = new();
        FreeFlyState = new();

        _currentState = state;
    }
    
    public void UpdateState(IManager attack) =>
        _currentState.UpdateState(attack);

    public void SwitchState(IManager attack, IState state)
    {
        _currentState = state;
        _currentState.EnterState(attack);
    }
}