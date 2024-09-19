using System.Collections.Generic;
using UnityEngine;

public class FourthSpecialAttack : ActionState
{
    private readonly InputController _inputManager;

    public FourthSpecialAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        //fsm.PlayerModel.Attacking();
        fsm.Animator.SetBool(nameof(FourthSpecialAttack), true);
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(FourthSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.FourthSpecialAttackValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}