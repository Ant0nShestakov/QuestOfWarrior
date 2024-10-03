using UnityEngine;

public enum CooldownTypes
{
    AutoAttack,
    FirstSpecialAttack,
    SecondSpecialAttack,
    ThirdSpecialAttack,
    FourthSpecialAttack,
    FifthSpecialAttack,
    SixSpecialAttack,
    SeventhSpecialAttack
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

    public bool CheckCooldownStemp()
    {
        if (Type == CooldownTypes.AutoAttack)
            return true;

        if (Time.time < CooldownCurrentTime + CooldownTime)
            return false;

        CooldownCurrentTime = Time.time;

        Debug.Log(Time.time);
        return true;
    }

    public void SetDefaultState() => CooldownCurrentTime = -CooldownTime;
}
