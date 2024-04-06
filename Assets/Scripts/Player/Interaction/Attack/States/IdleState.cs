using UnityEngine;

public class IdleState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.Animator.SetBool("isBlock", false);
        manager.Animator.SetBool("isAttack", false);
    }

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse0))
            manager.SwitchState(manager.StateSwitcher.AutoAttackState.Value);
        else if (Input.GetKey(KeyCode.Mouse1) && IsNotMoving())
            manager.SwitchState(manager.StateSwitcher.BlockState.Value);
        else if (Input.GetKey(KeyCode.F) && manager.PlayerModel.CheckStaminaForAttack(manager.StateSwitcher.SpecialStrongAttackState.Value))
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackState.Value);
        else if (Input.GetKey(KeyCode.R) && manager.PlayerModel.CheckStaminaForAttack(manager.StateSwitcher.SpecialFastAttackState.Value))
            manager.SwitchState(manager.StateSwitcher.SpecialFastAttackState.Value);
    }
}