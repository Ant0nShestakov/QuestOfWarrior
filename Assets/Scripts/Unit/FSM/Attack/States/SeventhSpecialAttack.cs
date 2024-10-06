using System.Collections.Generic;

public class SeventhSpecialAttack : ActionState
{
    private readonly InputController _inputManager;

    public SeventhSpecialAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        if (((IAttackStateVisitor)fsm.Visitor).Visit(this))
            fsm.Animator.SetBool(nameof(SeventhSpecialAttack), true);
        else
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(SeventhSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.SeventhSpecialAttackValue == 0 && CheckCancelAnimation(fsm, 2, nameof(SeventhSpecialAttack)))
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}