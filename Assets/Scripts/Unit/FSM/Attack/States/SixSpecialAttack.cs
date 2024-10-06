using System.Collections.Generic;

public class SixSpecialAttack : ActionState
{
    private readonly InputController _inputManager;

    public SixSpecialAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        if (((IAttackStateVisitor)fsm.Visitor).Visit(this))
            fsm.Animator.SetBool(nameof(SixSpecialAttack), true);
        else
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }

    public override void ExitState(IFSM fsm) 
    {
        fsm.Animator.SetBool(nameof(SixSpecialAttack), false);
    }

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.SixSpecialAttackValue == 0 && CheckCancelAnimation(fsm, 2, nameof(SixSpecialAttack)))
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}