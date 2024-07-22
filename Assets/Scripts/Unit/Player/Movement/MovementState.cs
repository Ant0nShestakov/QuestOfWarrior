public abstract class MovementState : IState
{
    public abstract void EnterState(IManager movement);
    public abstract void ExitState(IManager movement);
    public abstract void UpdateState(IManager movement);
}