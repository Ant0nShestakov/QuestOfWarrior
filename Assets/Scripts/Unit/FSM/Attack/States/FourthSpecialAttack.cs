using System.Collections.Generic;

public class FourthSpecialAttack : ActionState
{
    private readonly InputController _inputManager;

    public FourthSpecialAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        if (((IAttackStateVisitor)fsm.Visitor).Visit(this))
            fsm.Animator.SetBool(nameof(FourthSpecialAttack), true);
        else
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(FourthSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (CheckCancelAnimation(fsm, 2, nameof(FourthSpecialAttack)))
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}