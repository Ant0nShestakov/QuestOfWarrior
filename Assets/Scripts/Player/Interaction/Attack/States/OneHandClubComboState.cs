using UnityEngine;

public class OneHandClubComboState : AttackState
{
    public override void EnterState(IManager manager)
    {
        manager.PlayerModel.Attacking();
        manager.Animator.SetBool("OneHandClubCombo", true);
    }

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("OneHandClubCombo", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) || !manager.PlayerModel.TryCast(CooldownTypes.OneHandClubCombo, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
    }
}