using UnityEngine;

public class SwimState : MovementState
{

    public override void EnterState(IManager movement)
    {
        movement.PlayerModel.SetSwimSpeedState();
        movement.Animator.SetBool("isSwim", true);
    }

    public override void ExitState(IManager movement)
    {
        movement.Animator.SetBool("isSwim", false);
    }

    public override void UpdateState(IManager movement)
    {
        if(movement.PlayerModel.IsOnGround) 
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
