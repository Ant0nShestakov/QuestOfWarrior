using UnityEngine;

public class SpecialFastAttack : AttackState
{
    public override void EnterState(PlayerAttackManager manager)
    {
        manager.Animator.SetBool("isSpecialFastAttack", true);
    }

    public void ExitState(PlayerAttackManager manager)
    {
        manager.Animator.SetBool("isSpecialFastAttack", false);
    }

    public override void UpdateState(PlayerAttackManager manager)
    {
        if (Input.GetKeyUp(KeyCode.R) || !IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.IdleState);
        }
        else if (Input.GetKey(KeyCode.F) && !IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.SpecialAttackState);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackState);
        }
    }
}