using UnityEngine;

[RequireComponent (typeof(PhysicsController))]
public abstract class Controller : MonoBehaviour
{
    public abstract IDamageable Damageable { get; }
}