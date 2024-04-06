using UnityEngine;

public interface IManager
{
    public Animator Animator { get; }
    public PlayerModel PlayerModel { get; }
    public StateSwitcher StateSwitcher { get; }
    public CharacterController CharacterController { get; }
    public bool IsOnGround { get; }

    public void SwitchState(IState state);
}