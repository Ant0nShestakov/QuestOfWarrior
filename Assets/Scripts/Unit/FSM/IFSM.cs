using System.Collections.Generic;
using UnityEngine;

public interface IFSM
{
    public Animator Animator { get; }

    public IReadOnlyDictionary<string, ActionState> States { get; }

    public IIdleStateVisitor Visitor { get; }

    public void Update();

    public void SwitchState(ActionState actionState);
}