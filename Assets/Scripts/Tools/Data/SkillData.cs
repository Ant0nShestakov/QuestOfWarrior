using System;
using UnityEngine;

[Serializable]
public class SkillData
{
    [SerializeField] private string _name;
    [SerializeField] private CooldownTypes _cooldownType;
    [SerializeField] private int _damage;
    [SerializeField] private int _stamina;
    [SerializeField] private int _cooldownTime;
    [SerializeField] private float _cooldownCurrentTime;

    public CooldownTypes CooldownType { get => _cooldownType; }
    public int Damage { get => _damage; }
    public int Stamina { get => _stamina; }
    public string Name { get => _name;}
    public int CooldownTime { get => _cooldownTime; }
    public float CooldownCurrentTime { get => _cooldownCurrentTime; }

    public SkillData(Skill skill)
    {
        _cooldownType = skill.Type;
        _damage = skill.Damage;
        _stamina = skill.Stamina;
        _cooldownTime = skill.CooldownTime;
        _name = skill.name;
        _cooldownCurrentTime -= this._cooldownTime;
    }
}