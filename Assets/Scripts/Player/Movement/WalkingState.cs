using UnityEngine;

public class WalkingState : MovenetState
{
    public override void EnterState(PlayerMovemenManager movement)
    {
        movement.SetWalkSpeedState();
        movement.Animator.SetBool("isWalking", true);
    }

    public override void ExitState(PlayerMovemenManager movement)
    {
        movement.Animator.SetBool("isWalking", false);
    }

    public override void UpdateState(PlayerMovemenManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ExitState(movement);
            movement.SwitchState(movement.RuningState);
        }
    }
}