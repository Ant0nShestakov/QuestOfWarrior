using UnityEngine;

public class SpecialStrongAttackWithJumpState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.Attacking();
        manager.Animator.SetBool("isSpecialStrongAttackWithJump", true);
    }

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("isSpecialStrongAttackWithJump", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.Q) || !manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttackWithJump, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
    }
}