using UnityEngine;

public class AttackState : InteractionState
{
    public override void EnterState(PlayerInteractionManager manager)
    {
        manager.Animator.SetBool("isAttack", true);
    }

    public void ExitState(PlayerInteractionManager manager)
    {
        manager.Animator.SetBool("isAttack", false);
    }

    public override void UpdateState(PlayerInteractionManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            ExitState(manager);
            manager.SwitchState(manager.BlockState);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ExitState(manager);
            manager.SwitchState(manager.IdleState);
        }
    }
}