using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : ActionState
{
    private readonly InputController _inputManager;

    public AutoAttack (InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm) =>
        fsm.Animator.SetBool("isAttack", true);

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool("isAttack", false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.AutoAttackValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}