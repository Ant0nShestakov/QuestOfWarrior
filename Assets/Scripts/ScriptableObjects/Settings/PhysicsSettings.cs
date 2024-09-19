using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Settings/Physics")]
public class PhysicsSettings : ScriptableObject 
{
    [Header("Min mass"), Min(0)]
    [field:SerializeField] public float MinMass {  get; private set; }

    [Header("Middle mass"), Min(0)]
    [field: SerializeField] public float MiddleMass { get; private set; }
    [field: SerializeField] public float MiddleMassDebuff { get; private set; }

    [Header("Cap mass"), Min(0)]
    [field: SerializeField] public float CapMass { get; private set; }
    [field: SerializeField] public float CapMassDebuff { get; private set; }

    public void CalculateDirection(ref Vector3 direction, float mass)
    {
        if (mass <= MinMass)
            return;

        if (mass <= MiddleMass)
        {
            direction *= MiddleMassDebuff;
            return;
        }

        direction *= CapMassDebuff;
    }
}
