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
        if (((IAttackStateVisitor)fsm.Visitor).Visit(this))
            fsm.Animator.SetBool(nameof(FirstSpecialAttack), true);
        else
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }


    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(FirstSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (CheckCancelAnimation(fsm, 2, nameof(FirstSpecialAttack)))
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}