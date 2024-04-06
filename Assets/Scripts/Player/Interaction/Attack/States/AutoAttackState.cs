using UnityEngine;

public class AutoAttackState : AttackState
{
    public override void EnterState(PlayerAttackManager manager) =>
        manager.Animator.SetBool("isAttack", true);

    public void ExitState(PlayerAttackManager manager) =>
        manager.Animator.SetBool("isAttack", false);

    public override void UpdateState(PlayerAttackManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse1) && IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.BlockState);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.IdleState);
        }
        else if (Input.GetKey(KeyCode.F) && manager.PlayerModel.CheckStaminaForAttack(manager.AttackStateSwitcher.SpecialStrongAttackState))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.SpecialStrongAttackState);
        }
        else if (Input.GetKey(KeyCode.R) && manager.PlayerModel.CheckStaminaForAttack(manager.AttackStateSwitcher.SpecialFastAttackState))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.SpecialFastAttackState);
        }
    }
}