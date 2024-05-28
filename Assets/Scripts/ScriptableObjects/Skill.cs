using UnityEngine;

public enum CooldownTypes
{
    SpecialStrongAttack, 
    SpecialFastAttack, 
    AutoAttack, 
    SpecialStrongAttackWithJump, 
    OneHandClubCombo, 
    SwordAndShieldSpecialAttack,
    SpecialAttackOnLeft,
    JumpAttack
}

[CreateAssetMenu(fileName = "Skill", menuName = "ScritableObjects/Skill")]
public class Skill : ScriptableObject
{
    [field: SerializeField] public CooldownTypes Type { get; set; }
    [field: SerializeField] public int CooldownTime { get; set; }
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public int Stamina { get; set; }

    public float CooldownCurrentTime { get; set; }


    private void OnEnable()
    {
        CooldownCurrentTime = -CooldownTime;
    }

    public bool CheckCooldownStemp(float time)
    {
        if (Type == CooldownTypes.AutoAttack)
            return true;

        if (time < CooldownCurrentTime + CooldownTime)
            return false;

        CooldownCurrentTime = time;
        return true;
    }

    public void SetDefaultState() => CooldownCurrentTime = -CooldownTime;
}
