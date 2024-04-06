using UnityEngine;

public class SpecialStrongAttackState : AttackState
{
    public override void EnterState(PlayerAttackManager manager) =>        
        manager.Animator.SetBool("isSpecialAttack", true);

    public void ExitState(PlayerAttackManager manager) =>
        manager.Animator.SetBool("isSpecialAttack", false);

    public override void UpdateState(PlayerAttackManager manager)
    {
        if (Input.GetKeyUp(KeyCode.F) || !manager.PlayerModel.CheckStaminaForAttack(manager.AttackStateSwitcher.SpecialStrongAttackState))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.IdleState);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.AutoAttackState);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.SpecialFastAttackState);
        }
    }
}