public class JumpingState : MovenetState
{
    public override void EnterState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("isJump", true);
    }

    public override void ExitState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("isJump", false);
    }

    public override void UpdateState(PlayerMovemenManager movement)
    {
        if(!movement.isOnGround) 
        {
            ExitState(movement);
            movement.SwitchState(movement.FreeFlyState);
        }
    }
}
