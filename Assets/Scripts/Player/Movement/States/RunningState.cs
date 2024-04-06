using UnityEngine;

public class RunningState : MovementState
{
    public RunningState() : base() { }

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
            movement.SwitchState(movement.RealMovementState.WalkingState);
        }
        else if (Input.GetKey(KeyCode.Space) && movement.isOnGround) 
        {
            ExitState(movement);
            movement.SwitchState(movement.RealMovementState.JumpingState);
            movement.CharacterController.Move(new Vector3(0, movement.PlayerModel.JumpForce, 0).normalized);
        }
    }
}