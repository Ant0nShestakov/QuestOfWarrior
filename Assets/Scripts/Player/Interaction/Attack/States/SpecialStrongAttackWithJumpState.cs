using UnityEngine;

public class SpecialStrongAttackWithJumpState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.Attacking();
        manager.Animator.SetBool("isSpecialStrongAttackWithJump", true);
    }

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("isSpecialStrongAttackWithJump", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.Q) && !manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttackWithJump, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
        else if (Input.GetKey(KeyCode.Mouse0) && manager.PlayerModel.TryCast(CooldownTypes.AutoAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.AutoAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.R) && manager.PlayerModel.TryCast(CooldownTypes.SpecialFastAttack, Time.time)) 
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialFastAttackState.Value);
        }
        else if(Input.GetKey(KeyCode.F) && manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialStrongAttackState.Value);
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