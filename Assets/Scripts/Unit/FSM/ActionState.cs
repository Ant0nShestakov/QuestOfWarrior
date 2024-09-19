public abstract class ActionState
{
    public abstract void EnterState(IFSM fsm);
    public abstract void ExitState(IFSM fsm);
    public abstract void UpdateState(IFSM fsm);
}
