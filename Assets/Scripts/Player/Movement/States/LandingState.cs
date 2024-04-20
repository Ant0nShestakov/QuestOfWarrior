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
        if (movement.IsOnGround)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                ExitState(movement);
                movement.SwitchState(movement.StateSwitcher.RunningState.Value);
            }
            else if (Input.GetKey(KeyCode.Space) && movement.IsOnGround)
            {
                ExitState(movement);
                movement.SwitchState(movement.StateSwitcher.JumpingState.Value);
            }
            else
            {
                ExitState(movement);
                movement.SwitchState(movement.StateSwitcher.WalkingState.Value);
            }
        }

    }
}
