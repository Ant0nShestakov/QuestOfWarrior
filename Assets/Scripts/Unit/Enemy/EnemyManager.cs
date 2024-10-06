using UnityEngine;
using Pathfinding;
using System.Collections;
using System;

[RequireComponent(typeof(EnemyModel))]
public class EnemyManager : MonoBehaviour, IPooledObject<EnemyManager>
{
    [SerializeField] private float _animationTimeOfDeath;
    [SerializeField] private Transform _lookTransform;
    [SerializeField] private LayerMask _unitMask;

    private AIPath _aiPath;
    private EnemyModel _enemyModel;

    private GameObject _player;
    private AIDestinationSetter _destinationSetter;

    public event Action<EnemyManager> PushEvent;

    private void Awake()
    {
        _enemyModel = GetComponent<EnemyModel>();
        
        _aiPath = GetComponent<AIPath>();
        _aiPath.maxSpeed = _enemyModel.Speed;

        _destinationSetter = GetComponent<AIDestinationSetter>();
        _player = Singleton<UnitController>.Instance.gameObject;
    }

    private void OnEnable()
    {
        SetTarget();
        _enemyModel.ApplyDamageEvent += CheckHealth;
    }

    private void OnDisable()
    {
        PushEvent = null;

        if(_enemyModel != null)
            _enemyModel.ApplyDamageEvent -= CheckHealth;
    }

    private void Update()
    {
        if(Physics.Raycast(_lookTransform.position, transform.forward, out RaycastHit hit, _enemyModel.DistancePerAttack, _unitMask)) 
        {
            if (hit.collider.TryGetComponent<PlayerInteractionManager>(out PlayerInteractionManager _))
                _enemyModel.Animator.SetBool("isAttack", true);
        }

        _enemyModel.Animator.SetFloat("hInput", _aiPath.velocity.x);
        _enemyModel.Animator.SetFloat("vInput", _aiPath.velocity.z);
    }

    private void SetTarget() => _destinationSetter.target = _player.transform;
    
    private IEnumerator DeathEnemy()
    {
        yield return new WaitForSeconds(_animationTimeOfDeath);
        
        _enemyModel.Animator.SetBool("isDeath", false);
        _enemyModel.SetDefaultState();
        PushEvent?.Invoke(this);
    }

    private void CheckHealth(float currentHealth)
    {
        if (currentHealth <= 0)
        {
            _destinationSetter.target = null;
            _enemyModel.CharacterController.excludeLayers = 65;
            _enemyModel.Animator.SetBool("isDeath", true);
            StartCoroutine(DeathEnemy());
        }
    }
}
