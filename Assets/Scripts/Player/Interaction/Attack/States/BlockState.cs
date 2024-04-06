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
            manager.SwitchState(manager.AttackStateSwitcher.AutoAttackState);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) || !IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.IdleState);
        }
        else if (Input.GetKey(KeyCode.F) 
            && manager.PlayerModel.CheckStaminaForAttack(manager.AttackStateSwitcher.SpecialStrongAttackState))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.SpecialStrongAttackState);
        }
        else if (Input.GetKey(KeyCode.R) 
            && manager.PlayerModel.CheckStaminaForAttack(manager.AttackStateSwitcher.SpecialFastAttackState))
        {
            ExitState(manager);
            manager.SwitchState(manager.AttackStateSwitcher.SpecialFastAttackState);
        }
    }
}