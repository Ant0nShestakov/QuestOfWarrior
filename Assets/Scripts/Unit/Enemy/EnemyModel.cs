using System;
using UnityEngine;

public class EnemyModel : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyStats _enemyProperites;
    private CharacterController _characterController;

    public event Action<float> ApplyDamageEvent;

    public CharacterController CharacterController => _characterController;

    [field: SerializeField] public float Health { get; private set; }

    public float Speed { get => _enemyProperites.WalkSpeed; }
    public float DistancePerAttack { get => _enemyProperites.DistancePerAttack; }
    public float Damage { get => _enemyProperites.Damage; }
    public Animator Animator { get; private set; }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
        SetDefaultState();
    }

    public void SetDefaultState()
    {
        Health = _enemyProperites.Health;
        _characterController.excludeLayers = default;
    }

    public void ApplyDamage(float damage)
    {
        Health -= damage;
        ApplyDamageEvent?.Invoke(Health);
    }
}
