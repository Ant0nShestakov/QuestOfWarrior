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
        if (Input.GetKey(KeyCode.Mouse0) && manager.PlayerModel.TryCast(CooldownTypes.AutoAttack, Time.time))
            manager.SwitchState(manager.StateSwitcher.AutoAttackState.Value);
        else if (Input.GetKey(KeyCode.Mouse1) && IsNotMoving())
            manager.SwitchState(manager.StateSwitcher.BlockState.Value);
        else if (Input.GetKey(KeyCode.F) && manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttack, Time.time))
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackState.Value);
        else if (Input.GetKey(KeyCode.R) && manager.PlayerModel.TryCast(CooldownTypes.SpecialFastAttack, Time.time))
            manager.SwitchState(manager.StateSwitcher.SpecialFastAttackState.Value);
        else if (Input.GetKey(KeyCode.Q) && manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttackWithJump, Time.time))
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackWithJump.Value);
    }
}