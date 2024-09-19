using System.Collections.Generic;

public sealed class WalkState : ActionState
{
    private readonly InputController _inputManager;

    public WalkState(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        fsm.Visitor.Visit(this);
        fsm.Animator.SetBool("Walk", true);
    }

    public override void ExitState(IFSM fsm)
    {
        fsm.Animator.SetBool("Walk", false);
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