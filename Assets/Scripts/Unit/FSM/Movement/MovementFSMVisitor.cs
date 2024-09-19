using System;

public sealed class MovementFSMVisitor : IActionStateVisitor
{
    private readonly UnitModel _unitModel;

    public MovementFSMVisitor(UnitModel unitModel)
    {
        _unitModel = unitModel; 
    }

    public void Visit(ActionState state)
    {
        switch (state)
        {
            case WalkState:
                _unitModel.SetWalkSpeed();
                break;
            case RunState:
                _unitModel.SetRunSpeed();
                break;
            case CrouchState:
                _unitModel.SetCrouchSpeed();
                break;
            default:
                throw new InvalidOperationException($"{state.GetType()} is not registered in {nameof(MovementFSM)}");
        }

    }
}