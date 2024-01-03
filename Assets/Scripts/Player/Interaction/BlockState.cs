using UnityEngine;

public class BlockState : InteractionState
{
    public override void EnterState(PlayerInteractionManager manager)
    {
        manager.PlayerModel.IsBlocked = true;
        manager.Animator.SetBool("isBlock", true);
    }

    public void ExitState(PlayerInteractionManager manager)
    {
        manager.PlayerModel.IsBlocked = true;
        manager.Animator.SetBool("isBlock", false);
    }

    public override void UpdateState(PlayerInteractionManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackState);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ExitState(manager);
            manager.SwitchState(manager.IdleState);
        }
    }
}