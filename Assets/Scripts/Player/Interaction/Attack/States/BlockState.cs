using UnityEngine;

public class BlockState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.IsBlocked = true;
        manager.Animator.SetBool("isBlock", true);
    }

    public override void ExitState(IManager manager)
    {
        manager.PlayerModel.IsBlocked = false;
        manager.Animator.SetBool("isBlock", false);
    }

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.AutoAttackState.Value);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) || !IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
        else if (Input.GetKey(KeyCode.F)
            && manager.PlayerModel.IsCast(CooldownTypes.SpecialStrongAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.R)
            && manager.PlayerModel.IsCast(CooldownTypes.SpecialFastAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialFastAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.Q)
            && manager.PlayerModel.IsCast(CooldownTypes.SpecialStrongAttackWithJump, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackWithJump.Value);
        }
    }
}