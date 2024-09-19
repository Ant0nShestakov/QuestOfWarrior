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
        fsm.Visitor.Visit(this);
        fsm.Animator.SetBool(nameof(SixSpecialAttack), true);
    }

    public override void ExitState(IFSM fsm) 
    {
        fsm.Animator.SetBool(nameof(SixSpecialAttack), false);
    }

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.FifthSpecialAttackValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}