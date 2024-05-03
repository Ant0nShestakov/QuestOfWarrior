using UnityEngine;

public class AutoAttackState : AttackState
{
    public override void EnterState(IManager manager) =>
        manager.Animator.SetBool("isAttack", true);

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("isAttack", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse1) && IsNotMoving())
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.BlockState.Value);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
        else if (Input.GetKey(KeyCode.F) && manager.PlayerModel.IsCast(CooldownTypes.SpecialStrongAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.R) && manager.PlayerModel.IsCast(CooldownTypes.SpecialFastAttack, Time.time))
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