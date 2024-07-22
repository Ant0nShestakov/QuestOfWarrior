using System.Collections.Generic;
using System;
using UnityEngine;

public class IdleState : AttackState
{
    private Dictionary<KeyCode, Func<IManager, bool>> stateTransitions;

    public IdleState()
    {
        stateTransitions = new Dictionary<KeyCode, Func<IManager, bool>>
        {
            { KeyCode.Mouse0, m => m.PlayerModel.TryCast(CooldownTypes.AutoAttack, Time.time) },
            { KeyCode.Mouse1, m => IsNotMoving() },
            { KeyCode.F, m => m.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttack, Time.time) },
            { KeyCode.R, m => m.PlayerModel.TryCast(CooldownTypes.SpecialFastAttack, Time.time) },
            { KeyCode.Q, m => m.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttackWithJump, Time.time) },
            { KeyCode.Alpha1, m => m.PlayerModel.TryCast(CooldownTypes.OneHandClubCombo, Time.time) },
            { KeyCode.Alpha2, m => m.PlayerModel.TryCast(CooldownTypes.SwordAndShieldSpecialAttack, Time.time) },
            { KeyCode.Alpha4, m => m.PlayerModel.TryCast(CooldownTypes.SpecialAttackOnLeft, Time.time) },
            { KeyCode.Alpha3, m => m.PlayerModel.TryCast(CooldownTypes.JumpAttack, Time.time) }
        };
    }

    private IState GetStateForKey(KeyCode key, IManager manager)
    {
        switch (key)
        {
            case KeyCode.Mouse0:
                return manager.StateSwitcher.AutoAttackState.Value;
            case KeyCode.Mouse1:
                return manager.StateSwitcher.BlockState.Value;
            case KeyCode.F:
                return manager.StateSwitcher.SpecialStrongAttackState.Value;
            case KeyCode.R:
                return manager.StateSwitcher.SpecialFastAttackState.Value;
            case KeyCode.Q:
                return manager.StateSwitcher.SpecialStrongAttackWithJumpState.Value;
            case KeyCode.Alpha1:
                return manager.StateSwitcher.OneHandClubComboState.Value;
            case KeyCode.Alpha2:
                return manager.StateSwitcher.SwordAndShieldSpecialAttackState.Value;
            case KeyCode.Alpha4:
                return manager.StateSwitcher.SpecialAttackOnLeftState.Value;
            case KeyCode.Alpha3:
                return manager.StateSwitcher.JumpAttackState.Value;
            default:
                return manager.StateSwitcher.IdleState.Value;
        }
    }

    public override void EnterState(IManager manager)
    {
        manager.Animator.SetBool("isBlock", false);
        manager.Animator.SetBool("isAttack", false);
    }

    public override void UpdateState(IManager manager)
    {

        foreach (var key in stateTransitions.Keys)
        {
            if (Input.GetKey(key) && stateTransitions[key].Invoke(manager))
            {
                manager.SwitchState(GetStateForKey(key, manager));
                return;
            }
        }
    }
}