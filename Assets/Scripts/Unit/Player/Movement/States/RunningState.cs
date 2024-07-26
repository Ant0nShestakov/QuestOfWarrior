using UnityEngine;

public class RunningState : MovementState
{
    public override void EnterState(IManager movement)
    {
        movement.PlayerModel.PlayerProperites.SetRunSpeed();
        movement.Animator.SetBool("isRun", true);
    }

    public override void ExitState(IManager movement)
    {
        movement.Animator.SetBool("isRun", false);
    }

    public override void UpdateState(IManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ExitState(movement);
            movement.SwitchState(movement.StateSwitcher.WalkingState.Value);
        }
        else if (Input.GetKey(KeyCode.Space) && !movement.PlayerModel.IsGrounded)
        {
            ExitState(movement);
            movement.SwitchState(movement.StateSwitcher.FreeFlyState.Value);
        }
        else if (movement.PlayerModel.IsSwim)
        {
            ExitState(movement);
            movement.SwitchState(movement.StateSwitcher.SwimyState.Value);
        }
    }
}