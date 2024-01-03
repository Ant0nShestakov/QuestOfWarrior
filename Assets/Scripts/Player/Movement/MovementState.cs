public abstract class MovenetState
{
    public abstract void EnterState(PlayerMovemenManager movement);
    public abstract void ExitState(PlayerMovemenManager movement);
    public abstract void UpdateState(PlayerMovemenManager movement);
}