using System;

public class StateSwitcher
{
    private IState _currentState;

    #region smashStates
    public Lazy<AutoAttackState> AutoAttackState { get; private set; } 
    public Lazy<BlockState> BlockState { get; private set; }
    public Lazy<IdleState> IdleState { get; private set; }
    public Lazy<SpecialFastAttackState> SpecialFastAttackState { get; private set; }
    public Lazy<SpecialStrongAttackState> SpecialStrongAttackState { get; private set; }
    public Lazy<SpecialStrongAttackWithJumpState> SpecialStrongAttackWithJumpState { get; private set; }
    public Lazy<JumpAttackState> JumpAttackState { get; private set; }
    public Lazy<SpecialAttackOnLeftState> SpecialAttackOnLeftState { get; private set; }
    public Lazy<OneHandClubComboState> OneHandClubComboState { get; private set; }
    public Lazy<SwordAndShieldSpecialAttackState> SwordAndShieldSpecialAttackState { get; private set; }
    #endregion

    #region moveStates
    public Lazy<WalkingState> WalkingState { get; private set; }
    public Lazy<RunningState> RunningState { get; private set; }
    public Lazy<FreeFlyState> FreeFlyState { get; private set; }
    public Lazy<SwimState> SwimyState { get; private set; }
    #endregion

    public IState Current { get => _currentState; }

    public StateSwitcher(IState state)
    {
        InitAttackStates();
        InitMovementStates();

        _currentState = state;
    }
    
    private void InitAttackStates()
    {
        AutoAttackState = new();
        BlockState = new();
        IdleState = new();
        SpecialFastAttackState = new();
        SpecialStrongAttackState = new();
        SpecialStrongAttackWithJumpState = new();
        JumpAttackState = new();
        SpecialAttackOnLeftState = new();
        OneHandClubComboState = new();
        SwordAndShieldSpecialAttackState = new();
    }

    private void InitMovementStates()
    {
        WalkingState = new();
        RunningState = new();
        FreeFlyState = new();
        SwimyState = new();
    }

    public void UpdateState(IManager attack) =>
        _currentState.UpdateState(attack);

    public void SwitchState(IManager attack, IState state)
    {
        _currentState = state;
        _currentState.EnterState(attack);
    }
}