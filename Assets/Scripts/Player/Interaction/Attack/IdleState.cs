using UnityEngine;

public class IdleState : AttackState
{
    public override void EnterState(PlayerAttackManager manager)
    {
        manager.Animator.SetBool("isBlock", false);
        manager.Animator.SetBool("isAttack", false);
    }

    public override void UpdateState(PlayerAttackManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse0))
            manager.SwitchState(manager.AttackState);
        else if (Input.GetKey(KeyCode.Mouse1) && IsNotMoving())
            manager.SwitchState(manager.BlockState);
        else if (Input.GetKey(KeyCode.F) && IsNotMoving())
            manager.SwitchState(manager.SpecialAttackState);
        else if (Input.GetKey(KeyCode.R) && IsNotMoving())
            manager.SwitchState(manager.SpecialFastAttackState);
    }
}