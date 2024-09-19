using System;
using System.Linq;
using Unity.VisualScripting;

public sealed class AttackFSMVisitor : IActionStateVisitor
{
    private readonly UnitModel _unitModel;
    private readonly PhysicsController _physicsController;

    public AttackFSMVisitor(UnitModel unitModel)
    {
        _unitModel = unitModel; 
    }

    public void Visit(ActionState state)
    {
        switch (state)
        {
            case WalkState:
                _unitModel.SetWalkSpeed();
                break;
            case RunState:
                _unitModel.SetRunSpeed();
                break;
            case CrouchState:
                _unitModel.SetCrouchSpeed();
                break;
            default:
                throw new InvalidOperationException($"{state.GetType()} is not registered in {nameof(MovementFSM)}");
        }

    }

    private bool CheckStaminaForAttack(Skill cd)
    {
        if (_unitModel.PlayerProperites.CurrentStamina - cd.Stamina < 0)
            return false;
        return true;
    }

    private bool TryGetCooldownForType(CooldownTypes cooldownTypes, out Skill skill)
    {
        skill = _unitModel.Cooldowns.SingleOrDefault(cd => cd.Type == cooldownTypes);

        if (skill == null)
            return false;

        return true;
    }

    public bool TryCast(CooldownTypes cooldownTypes, float time)
    {
        if (_physicsController.IsGrounded || _unitModel.IsAttack)
            return false;

        if (!TryGetCooldownForType(cooldownTypes, out Skill cooldown))
            return false;

        if (!CheckStaminaForAttack(cooldown))
            return false;

        if (!cooldown.CheckCooldownStemp(time))
            return false;

        _unitModel.Damage = cooldown.Damage;
        _unitModel.PlayerProperites.CurrentStamina -= cooldown.Stamina;
        return true;
    }
}