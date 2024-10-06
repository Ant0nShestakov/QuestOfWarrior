public interface IMovementStateVisitor : IIdleStateVisitor
{
    public void Visit(RunState state);
    public void Visit(CrouchState state);
} 