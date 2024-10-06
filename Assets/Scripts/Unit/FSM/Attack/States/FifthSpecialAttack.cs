using System.Collections.Generic;

public class FifthSpecialAttack : ActionState
{
    private readonly InputController _inputManager;

    public FifthSpecialAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        if (((IAttackStateVisitor)fsm.Visitor).Visit(this))
            fsm.Animator.SetBool(nameof(FifthSpecialAttack), true);
        else
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(FifthSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.FifthSpecialAttackValue == 0 && CheckCancelAnimation(fsm, 2, nameof(FifthSpecialAttack)))
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}