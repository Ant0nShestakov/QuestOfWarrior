public class FreeFlyState : MovementState
{

    public FreeFlyState() : base() { }

    public override void EnterState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("isFreeFly", true);
    }

    public override void ExitState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("isFreeFly", false);
    }

    public override void UpdateState(PlayerMovemenManager movement)
    {
        if(movement.isOnGround) 
        {
            ExitState(movement);
            movement.SwitchState(movement.RealMovementState.LandingState);
        }
    }
}
