using UnityEngine;

public class WalkingState : MovenetState
{
    public override void EnterState(PlayerMovemenManager movement)
    {
        movement.PlayerModel.SetWalkSpeedState();
        movement.Animator.SetBool("isWalking", true);
    }

    public override void ExitState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("isWalking", false);
    }

    public override void UpdateState(PlayerMovemenManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift) && !movement.PlayerModel.IsStay)
        {
            ExitState(movement);
            movement.SwitchState(movement.RuningState);
        }
        else if (Input.GetKey(KeyCode.Space) && movement.isOnGround && !movement.PlayerModel.IsStay) 
        {
            ExitState(movement);
            movement.SwitchState(movement.JumpingState);
            movement.CharacterController.Move(new Vector3(0, movement.JumpForce * Time.deltaTime, 0).normalized);
        }
    }
}