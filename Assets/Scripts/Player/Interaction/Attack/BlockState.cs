using UnityEngine;

public class BlockState : AttackState
{
    public override void EnterState(PlayerAttackManager manager)
    {
        manager.PlayerModel.IsBlocked = true;
        manager.Animator.SetBool("isBlock", true);
    }

    public void ExitState(PlayerAttackManager manager)
    {
        manager.PlayerModel.IsBlocked = false;
        manager.Animator.SetBool("isBlock", false);
    }

    public override void UpdateState(PlayerAttackManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackState);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) || !IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.IdleState);
        }
        else if (Input.GetKey(KeyCode.F) && IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.SpecialAttackState);
        }
        else if (Input.GetKey(KeyCode.R) && IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.SpecialFastAttackState);
        }
    }
}