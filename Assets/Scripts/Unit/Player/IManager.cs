using UnityEngine;

public interface IManager
{
    public Animator Animator { get; }
    public PlayerModel PlayerModel { get; }
    public StateSwitcher StateSwitcher { get; }
    public void SwitchState(IState state);
}