public class FreeFlyState : MovementState
{

    public override void EnterState(IManager movement)
    {
        movement.Animator.SetBool("isFreeFly", true);
    }

    public override void ExitState(IManager movement)
    {
        movement.Animator.SetBool("isFreeFly", false);
    }

    public override void UpdateState(IManager movement)
    {
        if(movement.IsOnGround) 
        {
            ExitState(movement);
            movement.SwitchState(movement.StateSwitcher.WalkingState.Value);
        }
    }
}
