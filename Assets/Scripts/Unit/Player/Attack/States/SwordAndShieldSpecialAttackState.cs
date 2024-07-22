using UnityEngine;

public class SwordAndShieldSpecialAttackState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.Attacking();
        manager.Animator.SetBool("SwordAndShieldSpecialAttack", true);
    }

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("SwordAndShieldSpecialAttack", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.Alpha2) || !manager.PlayerModel.TryCast(CooldownTypes.SwordAndShieldSpecialAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
    }
}