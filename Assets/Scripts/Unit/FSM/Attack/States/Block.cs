using System.Collections.Generic;
using UnityEngine;

public class Block : ActionState 
{
    private readonly InputController _inputManager;

    public Block(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        //manager.PlayerModel.IsBlocked = true;
        fsm.Animator.SetBool(nameof(Block), true);
    }

    public override void ExitState(IFSM fsm)
    {
        //fsm.PlayerModel.IsBlocked = false;
        fsm.Animator.SetBool(nameof(Block), false);
    }

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.BlockValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }

    }
}