using System.Collections.Generic;

public class ThridSpecialAttack : ActionState
{
    private readonly InputController _inputManager;

    public ThridSpecialAttack(InputController inputManager)
    {
        _inputManager = inputManager;
    }

    public override void EnterState(IFSM fsm)
    {
       // fsm.PlayerModel.Attacking();
        fsm.Animator.SetBool(nameof(ThridSpecialAttack), true);
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(ThridSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.ThridSpecialAttackValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}