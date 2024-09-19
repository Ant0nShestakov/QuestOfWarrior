using System;
using System.Collections.Generic;
using UnityEngine;

public class IdleAttack : ActionState
{
    private readonly InputController _inputManager;

    public IdleAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM manager)
    {
        manager.Animator.SetBool(nameof(Block), false);
        manager.Animator.SetBool("isAttack", false);
    }

    public override void ExitState(IFSM fsm)
    {
        
    }

    public override void UpdateState(IFSM fsm)
    {
        if(_inputManager.AutoAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(AutoAttack)));
        }
        else if(_inputManager.BlockValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(Block)));
        }
        else if (_inputManager.FirstSpecialAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FirstSpecialAttack)));
        }
        else if(_inputManager.SecondSpecialAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(SecondSpecialAttack)));
        }
        else if (_inputManager.ThridSpecialAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(ThridSpecialAttack)));
        }
        else if (_inputManager.FourthSpecialAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FourthSpecialAttack)));
        }
        else if (_inputManager.FifthSpecialAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FifthSpecialAttack)));
        }
        else if (_inputManager.SixSpecialAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(SixSpecialAttack)));
        }
        else if (_inputManager.SeventhSpecialAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(SixSpecialAttack)));
        }
    }

}