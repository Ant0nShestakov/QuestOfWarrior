using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class AttackState : IState
{
    protected bool IsNotMoving() =>
        Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0;
   
    public abstract void EnterState(IManager manager);
    public abstract void UpdateState(IManager manager);

    public virtual void ExitState(IManager manager)
    {
        throw new System.NotImplementedException();
    }
}
