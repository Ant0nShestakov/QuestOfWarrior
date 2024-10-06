using System.Linq;
using UnityEngine;

public sealed class AttackFSMVisitor : IAttackStateVisitor
{
    private readonly UnitModel _unitModel;
    private readonly PhysicsController _physicsController;

    public AttackFSMVisitor(UnitModel unitModel, PhysicsController physicsController)
    {
        _unitModel = unitModel;
        _physicsController = physicsController;
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

    private bool TryCast(CooldownTypes cooldownTypes)
    {
        if (!_physicsController.IsGrounded || _unitModel.IsAttack)
            return false;

        if (!TryGetCooldownForType(cooldownTypes, out Skill cooldown))
            return false;

        Debug.Log(cooldown.name);

        if (!CheckStaminaForAttack(cooldown))
            return false;

        if (!cooldown.CheckCooldownStemp())
            return false;

        _unitModel.Damage = cooldown.Damage;
        _unitModel.PlayerProperites.CurrentStamina -= cooldown.Stamina;

        _unitModel.IsAttack = true;

        _unitModel.UpdateManaInfo();

        return true;
    }

    public bool Visit(IdleState state)
    {
        _unitModel.SetWalkSpeed();
        return true;
    }

    public bool Visit(Block state)
    {
        return true;
    }

    public bool Visit(FirstSpecialAttack state)
    {
        bool tryCast = TryCast(CooldownTypes.FirstSpecialAttack);

        if(tryCast)
            _unitModel.SetZeroSpeed();

        return tryCast;
    }

    public bool Visit(SecondSpecialAttack state)
    {
        bool tryCast = TryCast(CooldownTypes.SecondSpecialAttack);

        if (tryCast)
            _unitModel.SetZeroSpeed();

        return tryCast;
    }

    public bool Visit(ThridSpecialAttack state)
    {
        bool tryCast = TryCast(CooldownTypes.ThirdSpecialAttack);

        if (tryCast)
            _unitModel.SetZeroSpeed();

        return tryCast;
    }

    public bool Visit(FourthSpecialAttack state)
    {
        bool tryCast = TryCast(CooldownTypes.FourthSpecialAttack);

        if (tryCast)
            _unitModel.SetZeroSpeed();

        return tryCast;
    }

    public bool Visit(FifthSpecialAttack state)
    {
        bool tryCast = TryCast(CooldownTypes.FifthSpecialAttack);

        if (tryCast)
            _unitModel.SetZeroSpeed();

        return tryCast;
    }

    public bool Visit(SixSpecialAttack state)
    {
        bool tryCast = TryCast(CooldownTypes.SixSpecialAttack);

        if (tryCast)
            _unitModel.SetZeroSpeed();

        return tryCast;
    }

    public bool Visit(SeventhSpecialAttack state)
    {
        bool tryCast = TryCast(CooldownTypes.SeventhSpecialAttack);

        if (tryCast)
            _unitModel.SetZeroSpeed();

        return tryCast;
    }

    public bool Visit(AutoAttack state)
    {
        return TryCast(CooldownTypes.AutoAttack);
    }
}