using UnityEngine;

public class AutoAttackState : AttackState
{
    public override void EnterState(PlayerAttackManager manager)
    {
        manager.Animator.SetBool("isAttack", true);
    }

    public void ExitState(PlayerAttackManager manager)
    {
        manager.Animator.SetBool("isAttack", false);
    }

    public override void UpdateState(PlayerAttackManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            ExitState(manager);
            manager.SwitchState(manager.BlockState);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
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