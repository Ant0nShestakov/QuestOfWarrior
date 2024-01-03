using UnityEngine;

public abstract class InteractionState
{
    protected bool IsMoving()
    {
        return Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0;
    }

    public abstract void EnterState(PlayerInteractionManager manager);
    public abstract void UpdateState(PlayerInteractionManager manager);
}
