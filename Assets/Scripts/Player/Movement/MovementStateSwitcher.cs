public class MovementStateSwitcher
{
    private MovementState _currentState;
    public WalkingState WalkingState { get; private set; }
    public RunningState RunningState { get; private set; }
    public JumpingState JumpingState { get; private set; }
    public FreeFlyState FreeFlyState { get; private set; }
    public LandingState LandingState { get; private set; }

    public MovementStateSwitcher()
    {
        WalkingState = new WalkingState();
        RunningState = new RunningState();
        JumpingState = new JumpingState();
        FreeFlyState = new FreeFlyState();
        LandingState = new LandingState();
        _currentState = WalkingState;
    }
    
    public void UpdateState(PlayerMovemenManager movement) =>
        _currentState.UpdateState(movement);

    public void SwitchState(PlayerMovemenManager movement, MovementState movementState)
    {
        _currentState = movementState;
        _currentState.EnterState(movement);
    }
}