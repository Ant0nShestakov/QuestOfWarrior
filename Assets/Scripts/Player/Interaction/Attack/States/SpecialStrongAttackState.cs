using UnityEngine;

public class SpecialStrongAttackState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.Attacking();
        manager.Animator.SetBool("isSpecialAttack", true);
    }

    public override void ExitState(IManager manager) 
    {
        manager.Animator.SetBool("isSpecialAttack", false);
    }

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.F) || !manager.PlayerModel.TryCast(CooldownTypes.SpecialStrongAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
    }
}