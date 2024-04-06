public class JumpingState : MovementState
{
    public override void EnterState(IManager movement)
    {
        movement.Animator.SetBool("isJump", true);
    }

    public override void ExitState(IManager movement)
    {
        movement.Animator.SetBool("isJump", false);
    }

    public override void UpdateState(IManager movement)
    {
        if (!movement.IsOnGround) 
        {
            ExitState(movement);
            movement.SwitchState(movement.StateSwitcher.FreeFlyState.Value);
        }
    }
}
