using System.Collections.Generic;

public sealed class WalkState : IdleState
{
    private readonly InputController _inputManager;

    public WalkState(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        ((IMovementStateVisitor)fsm.Visitor).Visit(this);
        fsm.Animator.SetBool("Walk", true);
    }

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.RunValue > 0)
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(RunState)));
        else if (!((MovementFSM)fsm).IsGrounded)
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FallState)));
        else if (_inputManager.CrouchValue > 0)
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(CrouchState)));
    }
}