using UnityEngine;

public class SpecialAttackOnLeftState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.Attacking();
        manager.Animator.SetBool("SpecialAttackOnLeft", true);
    }

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("SpecialAttackOnLeft", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.Alpha4) || !manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttackWithJump, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
    }
}