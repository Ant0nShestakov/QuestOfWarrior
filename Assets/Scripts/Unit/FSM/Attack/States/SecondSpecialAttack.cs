using System.Collections.Generic;

public class SecondSpecialAttack : ActionState
{
    private readonly InputController _inputManager;

    public SecondSpecialAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        if (((IAttackStateVisitor)fsm.Visitor).Visit(this))
            fsm.Animator.SetBool(nameof(SecondSpecialAttack), true);
        else
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(SecondSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.SecondSpecialAttackValue == 0 && CheckCancelAnimation(fsm, 2, nameof(SecondSpecialAttack)))
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}