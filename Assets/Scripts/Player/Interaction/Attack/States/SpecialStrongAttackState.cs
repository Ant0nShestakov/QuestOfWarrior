using UnityEngine;

public class SpecialStrongAttackState : AttackState
{
    public override void EnterState(IManager manager) =>        
        manager.Animator.SetBool("isSpecialAttack", true);

    public override void ExitState(IManager manager) =>
        manager.Animator.SetBool("isSpecialAttack", false);

    public override void UpdateState(IManager manager)
    {
        if (Input.GetKeyUp(KeyCode.F) && !manager.PlayerModel.IsCast(CooldownTypes.SpecialStrongAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.IdleState.Value);
        }
        else if (Input.GetKey(KeyCode.Mouse0) && manager.PlayerModel.IsCast(CooldownTypes.AutoAttack, Time.time))
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.AutoAttackState.Value);
        }
        else if (Input.GetKey(KeyCode.R) && manager.PlayerModel.IsCast(CooldownTypes.SpecialFastAttack, Time.time)) 
        {
            ExitState(manager);
            manager.SwitchState(manager.StateSwitcher.SpecialFastAttackState.Value);
        }
    }
}