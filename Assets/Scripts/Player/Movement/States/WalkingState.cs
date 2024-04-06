using UnityEngine;

public class WalkingState : MovementState
{
    public WalkingState() : base() { }

    public override void EnterState(IManager movement)
    {
        movement.PlayerModel.SetWalkSpeedState();
        movement.Animator.SetBool("isWalking", true);
    }

    public override void ExitState(IManager movement)
    {
        movement.Animator.SetBool("isWalking", false);
    }

    public override void UpdateState(IManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift) && !movement.PlayerModel.IsStay)
        {
            ExitState(movement);
            movement.SwitchState(movement.StateSwitcher.RunningState.Value);
        }
        else if (Input.GetKey(KeyCode.Space) && movement.IsOnGround && !movement.PlayerModel.IsStay) 
        {
            ExitState(movement);
            movement.SwitchState(movement.StateSwitcher.JumpingState.Value);
            movement.CharacterController.Move(new Vector3(0, movement.PlayerModel.JumpForce * Time.deltaTime, 0).normalized);
        }
    }
}