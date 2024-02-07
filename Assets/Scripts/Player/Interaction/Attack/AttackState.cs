using UnityEngine;

public abstract class AttackState
{
    protected bool IsNotMoving()
    {
        return Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0;
    }

    public abstract void EnterState(PlayerAttackManager manager);
    public abstract void UpdateState(PlayerAttackManager manager);
}
