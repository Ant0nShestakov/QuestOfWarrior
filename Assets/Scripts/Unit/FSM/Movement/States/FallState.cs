using System.Collections.Generic;

public sealed class FallState : ActionState
{
    private readonly InputController _inputManager;

    public FallState(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        fsm.Animator.SetBool("Fall", true);
    }

    public override void ExitState(IFSM fsm)
    {
        fsm.Animator.SetBool("Fall", false);
    }

    public override void UpdateState(IFSM fsm)
    {
        if (((MovementFSM)fsm).IsGrounded)
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(WalkState)));
    }
}