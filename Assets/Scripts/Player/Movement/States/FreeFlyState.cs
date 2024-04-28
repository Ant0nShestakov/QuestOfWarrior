using UnityEngine;

public class FreeFlyState : MovementState
{

    public override void EnterState(IManager movement)
    {
        movement.Animator.SetBool("isFreeFly", true);
    }

    public override void ExitState(IManager movement)
    {
        movement.Animator.SetBool("isFreeFly", false);
    }

    public override void UpdateState(IManager movement)
    {
        if(movement.PlayerModel.IsOnGround && !movement.PlayerModel.IsFreeFly) 
        {
            ExitState(movement);
            if(Input.GetKey(KeyCode.LeftShift)) 
            {
                movement.SwitchState(movement.StateSwitcher.RunningState.Value);
                return;
            }
            movement.SwitchState(movement.StateSwitcher.WalkingState.Value);
        }
    }
}
