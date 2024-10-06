using System.Collections.Generic;

public sealed class RunState : ActionState
{
    private readonly InputController _inputManager;

    public RunState(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        ((IMovementStateVisitor)fsm.Visitor).Visit(this);
        fsm.Animator.SetBool("Run", true);
    }

    public override void ExitState(IFSM fsm)
    {
        fsm.Animator.SetBool("Run", false);
    }

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.RunValue == 0)
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(WalkState)));
        else if (!((MovementFSM)fsm).IsGrounded)
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FallState)));
    }
}