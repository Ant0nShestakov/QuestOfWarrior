using UnityEngine;

public class AutoAttackState : AttackState
{
    public override void EnterState(IManager manager) =>
        manager.Animator.SetBool("isAttack", true);

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("isAttack", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
    }
}