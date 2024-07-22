using UnityEngine;

public class SpecialFastAttackState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.Attacking();
        manager.Animator.SetBool("isSpecialFastAttack", true);
    }

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("isSpecialFastAttack", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.R) || !manager.PlayerModel.TryCast(CooldownTypes.SpecialFastAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
    }
}