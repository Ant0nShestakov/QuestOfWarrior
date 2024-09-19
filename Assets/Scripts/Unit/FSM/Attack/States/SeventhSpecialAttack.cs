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
        fsm.Visitor.Visit(this);
        fsm.Animator.SetBool(nameof(SeventhSpecialAttack), true);
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(SeventhSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.SeventhSpecialAttackValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}