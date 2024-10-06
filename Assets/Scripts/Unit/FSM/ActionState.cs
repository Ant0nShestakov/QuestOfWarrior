using UnityEngine;

public abstract class ActionState
{
    protected bool CheckCancelAnimation(IFSM fsm, int layerIndex, string animationName)
    {
        AnimatorStateInfo stateInfo = fsm.Animator.GetCurrentAnimatorStateInfo(layerIndex);

        if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f)
            return true;

        return false;
    }

    public abstract void EnterState(IFSM fsm);
    public abstract void ExitState(IFSM fsm);
    public abstract void UpdateState(IFSM fsm);
}
