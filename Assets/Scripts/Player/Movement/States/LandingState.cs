using UnityEngine;

public class LandingState : MovementState
{
    public LandingState() : base() { }

    public override void EnterState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("IsLanding", true);
    }

    public override void ExitState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("IsLanding", false);
    }

    public override void UpdateState(PlayerMovemenManager movement)
    {
        if(movement.isOnGround) 
        {
            ExitState(movement);
            if(Input.GetKey(KeyCode.LeftShift)) 
                movement.SwitchState(movement.RealMovementState.RunningState);
            else
                movement.SwitchState(movement.RealMovementState.WalkingState);
        }

    }
}
