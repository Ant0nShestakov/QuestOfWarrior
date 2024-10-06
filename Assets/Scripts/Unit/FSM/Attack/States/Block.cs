using System.Collections.Generic;

public class Block : ActionState 
{
    private readonly InputController _inputManager;

    public Block(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        ((IAttackStateVisitor)fsm.Visitor).Visit(this);
        fsm.Animator.SetBool(nameof(Block), true);
    }

    public override void ExitState(IFSM fsm)
    {
        fsm.Animator.SetBool(nameof(Block), false);
    }

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.BlockValue == 0 || _inputManager.IsMoved())
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}