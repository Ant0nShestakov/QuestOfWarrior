public abstract class MovementState
{
    public abstract void EnterState(PlayerMovemenManager movement);
    public abstract void ExitState(PlayerMovemenManager movement);
    public abstract void UpdateState(PlayerMovemenManager movement);
}