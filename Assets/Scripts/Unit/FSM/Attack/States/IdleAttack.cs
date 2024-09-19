using System.Collections.Generic;

public class IdleAttack : ActionState
{
    private readonly InputController _inputManager;

    public IdleAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
        fsm.Visitor.Visit(this);
        fsm.Animator.SetBool(nameof(Block), false);
        fsm.Animator.SetBool("isAttack", false);
    }

    public override void ExitState(IFSM fsm)
    {
        
    }

    public override void UpdateState(IFSM fsm)
    {
        if(_inputManager.AutoAttackValue > 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(AutoAttack)));
        }
        else if(_inputManager.BlockValue > 0)
        {
            if (_inputManager.IsMoved())
                return;

            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(Block)));
        }
        else if (_inputManager.FirstSpecialAttackValue > 0)
        {
            if (!((AttackFSMVisitor)fsm.Visitor).TryCast(CooldownTypes.FirstSpecialAttack))
                return;

            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FirstSpecialAttack)));
        }
        else if(_inputManager.SecondSpecialAttackValue > 0)
        {
            if (!((AttackFSMVisitor)fsm.Visitor).TryCast(CooldownTypes.SecondSpecialAttack))
                return;

            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(SecondSpecialAttack)));
        }
        else if (_inputManager.ThridSpecialAttackValue > 0)
        {
            if (!((AttackFSMVisitor)fsm.Visitor).TryCast(CooldownTypes.ThirdSpecialAttack))
                return;

            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(ThridSpecialAttack)));
        }
        else if (_inputManager.FourthSpecialAttackValue > 0)
        {
            if (!((AttackFSMVisitor)fsm.Visitor).TryCast(CooldownTypes.FourthSpecialAttack))
                return;

            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FourthSpecialAttack)));
        }
        else if (_inputManager.FifthSpecialAttackValue > 0)
        {
            if (!((AttackFSMVisitor)fsm.Visitor).TryCast(CooldownTypes.FifthSpecialAttack))
                return;

            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(FifthSpecialAttack)));
        }
        else if (_inputManager.SixSpecialAttackValue > 0)
        {
            if (!((AttackFSMVisitor)fsm.Visitor).TryCast(CooldownTypes.SixSpecialAttack))
                return;

            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(SixSpecialAttack)));
        }
        else if (_inputManager.SeventhSpecialAttackValue > 0)
        {
            if (!((AttackFSMVisitor)fsm.Visitor).TryCast(CooldownTypes.SeventhSpecialAttack))
                return;

            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(SixSpecialAttack)));
        }
    }

}