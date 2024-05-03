using UnityEngine;

public class SpecialFastAttackState : AttackState
{
    public override void EnterState(IManager manager) =>
        manager.Animator.SetBool("isSpecialFastAttack", true);

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("isSpecialFastAttack", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.R) && !manager.PlayerModel.IsCast(CooldownTypes.SpecialFastAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
        else if (Input.GetKey(KeyCode.F) && manager.PlayerModel.IsCast(CooldownTypes.SpecialStrongAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.AutoAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.Q)
            && manager.PlayerModel.IsCast(CooldownTypes.SpecialStrongAttackWithJump, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackWithJump.Value);
        }
    }
}