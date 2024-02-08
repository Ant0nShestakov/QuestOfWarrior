using UnityEngine;

public class SpecialStrongAttack : AttackState
{
    public override void EnterState(PlayerAttackManager manager)
    {
        manager.Animator.SetBool("isSpecialAttack", true);
    }

    public void ExitState(PlayerAttackManager manager)
    {
        manager.Animator.SetBool("isSpecialAttack", false);
    }

    public override void UpdateState(PlayerAttackManager manager)
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            ExitState(manager);
            manager.SwitchState(manager.IdleState);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackState);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            ExitState(manager);
            manager.SwitchState(manager.SpecialFastAttackState);
        }
    }
}