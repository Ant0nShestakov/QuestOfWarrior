using UnityEngine;

public class RunningState : MovenetState
{
    public override void EnterState(PlayerMovemenManager movement)
    {
        movement.PlayerModel.SetRunSpeedState();
        movement.Animator.SetBool("isRun", true);
    }

    public override void ExitState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("isRun", false);
    }

    public override void UpdateState(PlayerMovemenManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ExitState(movement);
            movement.SwitchState(movement.WalkingState);
        }
        else if (Input.GetKey(KeyCode.Space) && movement.isOnGround) 
        {
            ExitState(movement);
            movement.SwitchState(movement.JumpingState);
            movement.CharacterController.Move(new Vector3(0, movement.JumpForce, 0).normalized);
        }
    }
}