using UnityEngine;

public class BlockState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.IsBlocked = true;
        manager.Animator.SetBool("isBlock", true);
    }

    public override void ExitState(IManager manager)
    {
        manager.PlayerModel.IsBlocked = false;
        manager.Animator.SetBool("isBlock", false);
    }

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.Mouse1) || !IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
    }
}