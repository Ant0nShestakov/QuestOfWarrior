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
        else if ((Input.GetKey(KeyCode.Space) && !movement.PlayerModel.IsOnGround) || movement.PlayerModel.IsFreeFly) 
        {
            ExitState(movement);
            movement.SwitchState(movement.StateSwitcher.FreeFlyState.Value);
        }
    }
}