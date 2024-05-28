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
        this._cooldownType = skill.Type;
        this._damage = skill.Damage;
        this._stamina = skill.Stamina;
        this._cooldownTime = skill.CooldownTime;
        this._name = skill.name;
        this._cooldownCurrentTime -= this._cooldownTime;
    }
}