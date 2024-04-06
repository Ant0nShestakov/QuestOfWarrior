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
            manager.SwitchState(manager.AttackStateSwitcher.AutoAttackState);
        else if (Input.GetKey(KeyCode.Mouse1) && IsNotMoving())
            manager.SwitchState(manager.AttackStateSwitcher.BlockState);
        else if (Input.GetKey(KeyCode.F) && manager.PlayerModel.CheckStaminaForAttack(manager.AttackStateSwitcher.SpecialStrongAttackState))
            manager.SwitchState(manager.AttackStateSwitcher.SpecialStrongAttackState);
        else if (Input.GetKey(KeyCode.R) && manager.PlayerModel.CheckStaminaForAttack(manager.AttackStateSwitcher.SpecialFastAttackState))
            manager.SwitchState(manager.AttackStateSwitcher.SpecialFastAttackState);
    }
}