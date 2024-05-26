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
        else if (Input.GetKey(KeyCode.F) && manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.R) && manager.PlayerModel.TryCast(CooldownTypes.SpecialFastAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialFastAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.Q)
            && manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttackWithJump, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackWithJumpState.Value);
        }
        else if (Input.GetKey(KeyCode.Alpha1) && manager.PlayerModel.TryCast(CooldownTypes.OneHandClubCombo, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.OneHandClubComboState.Value);
        }
        else if (Input.GetKey(KeyCode.Alpha2) && manager.PlayerModel.TryCast(CooldownTypes.SwordAndShieldSpecialAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SwordAndShieldSpecialAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.Alpha4) && manager.PlayerModel.TryCast(CooldownTypes.SpecialAttackOnLeft, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialAttackOnLeftState.Value);
        }
        else if (Input.GetKey(KeyCode.Alpha3) && manager.PlayerModel.TryCast(CooldownTypes.JumpAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.JumpAttackState.Value);
        }
    }
}