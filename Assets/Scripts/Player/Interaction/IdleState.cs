using UnityEngine;

public class IdleState : InteractionState
{
    public override void EnterState(PlayerInteractionManager manager)
    {
        manager.Animator.SetBool("isBlock", false);
        manager.Animator.SetBool("isAttack", false);
    }

    public override void UpdateState(PlayerInteractionManager manager)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            manager.SwitchState(manager.AttackState);
        }
        else if (Input.GetKey(KeyCode.Mouse1)) 
        {
            manager.SwitchState(manager.BlockState);
        }
    }
}