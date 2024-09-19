using System.Collections.Generic;

public sealed class CrouchState : ActionState
{
    private readonly InputController _inputManager;

    public CrouchState(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        fsm.Visitor.Visit(this);
        fsm.Animator.SetBool("Crouch", true);
    }

    public override void ExitState(IFSM fsm)
    {
        fsm.Animator.SetBool("Crouch", false);
    }

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.CrouchValue == 0)
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(WalkState)));
        else if (!((MovementFSM)fsm).IsGrounded)
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FallState)));
    }
}