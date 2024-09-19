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
        fsm.Visitor.Visit(this);
        fsm.Animator.SetBool(nameof(SecondSpecialAttack), true);
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(SecondSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.SecondSpecialAttackValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}