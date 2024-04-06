using UnityEngine;

public class LandingState : MovementState
{
    public override void EnterState(IManager movement)
    {
        movement.Animator.SetBool("IsLanding", true);
    }

    public override void ExitState(IManager movement)
    {
        movement.Animator.SetBool("IsLanding", false);
    }

    public override void UpdateState(IManager movement)
    {
        if(movement.IsOnGround) 
        {
            ExitState(movement);
            if(Input.GetKey(KeyCode.LeftShift)) 
                movement.SwitchState(movement.StateSwitcher.RunningState.Value);
            else
                movement.SwitchState(movement.StateSwitcher.WalkingState.Value);
        }

    }
}
