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
        //fsm.PlayerModel.Attacking();
        fsm.Animator.SetBool(nameof(FifthSpecialAttack), true);
    }

    public override void ExitState(IFSM fsm) =>
        fsm.Animator.SetBool(nameof(FifthSpecialAttack), false);

    public override void UpdateState(IFSM fsm)
    {
        if (_inputManager.SixSpecialAttackValue == 0)
        {
            ExitState(fsm);
            fsm.SwitchState(fsm.States.GetValueOrDefault(nameof(IdleAttack)));
        }
    }
}