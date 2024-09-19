using System.Collections.Generic;
using UnityEngine;

public class FirstSpecialAttack : ActionState
{
    private readonly InputController _inputManager;

    public FirstSpecialAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        fsm.Visitor.Visit(this);
        fsm.Animator.SetBool(nameof(FirstSpecialAttack), true);
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(FirstSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.FirstSpecialAttackValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}