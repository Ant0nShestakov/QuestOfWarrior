using System.Linq;
using UnityEngine;

public sealed class AttackFSMVisitor : IActionStateVisitor
{
    private readonly UnitModel _unitModel;
    private readonly PhysicsController _physicsController;

    public AttackFSMVisitor(UnitModel unitModel, PhysicsController physicsController)
    {
        _unitModel = unitModel;
        _physicsController = physicsController;
    }

    public void Visit(ActionState state)
    {
    }

    private bool CheckStaminaForAttack(Skill cd)
    {
        Debug.Log($"Current Stamina {_unitModel.PlayerProperites.CurrentStamina}");
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

    public bool TryCast(CooldownTypes cooldownTypes)
    {
        if (!_physicsController.IsGrounded || _unitModel.IsAttack)
            return false;

        Debug.Log("IsGrounded and not attack");

        if (!TryGetCooldownForType(cooldownTypes, out Skill cooldown))
            return false;

        Debug.Log(cooldown.name);

        if (!CheckStaminaForAttack(cooldown))
            return false;

        Debug.Log("Stamina check success");

        if (!cooldown.CheckCooldownStemp())
            return false;

        Debug.Log("Cast");
        _unitModel.Damage = cooldown.Damage;
        _unitModel.PlayerProperites.CurrentStamina -= cooldown.Stamina;

        _unitModel.IsAttack = true;

        return true;
    }
}