public interface IState
{
    public void EnterState(IManager manager);
    public void ExitState(IManager manager);
    public void UpdateState(IManager manager);
}