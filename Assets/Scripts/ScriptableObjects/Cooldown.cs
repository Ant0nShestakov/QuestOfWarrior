using UnityEngine;

public enum CooldownTypes
{
    SpecialStrongAttack, SpecialFastAttack, AutoAttack, SpecialStrongAttackWithJump
}

[CreateAssetMenu(fileName = "Cooldown", menuName = "ScritableObjects/Cooldowns")]
public class Cooldown: ScriptableObject
{
    [field: SerializeField] public CooldownTypes Type { get; private set; }
    [field: SerializeField] public int CooldownTime { get; private set; }
    public float CooldownCurrentTime { get; private set; }

    private void OnEnable()
    {
        CooldownCurrentTime = -CooldownTime;
    }

    public bool CheckCooldownStemp(float time)
    {
        if(Type == CooldownTypes.AutoAttack)
            return true;

        if (time < CooldownCurrentTime + CooldownTime)
            return false;

        CooldownCurrentTime = time;
        return true;
    }
}
