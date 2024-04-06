using UnityEngine;

public class SpecialFastAttackState : AttackState
{
    public override void EnterState(PlayerAttackManager manager) =>
        manager.Animator.SetBool("isSpecialFastAttack", true);

    public void ExitState(PlayerAttackManager manager) =>
        manager.Animator.SetBool("isSpecialFastAttack", false);

    public override void UpdateState(PlayerAttackManager manager)
    {
        if (Input.GetKeyUp(KeyCode.R) || !manager.PlayerModel.CheckStaminaForAttack(manager.AttackStateSwitcher.SpecialFastAttackState))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.IdleState);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.SpecialStrongAttackState);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.AutoAttackState);
        }
    }
}