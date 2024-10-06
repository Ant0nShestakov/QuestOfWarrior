using System;

public sealed class MovementFSMVisitor : IMovementStateVisitor
{
    private readonly UnitModel _unitModel;

    public MovementFSMVisitor(UnitModel unitModel)
    {
        _unitModel = unitModel; 
    }

    public void Visit(RunState state)
    {
        _unitModel.SetRunSpeed();
    }

    public void Visit(CrouchState state)
    {
        _unitModel.SetCrouchSpeed();
    }

    public bool Visit(IdleState state)
    {
        _unitModel.SetWalkSpeed();
        return true;
    }
}