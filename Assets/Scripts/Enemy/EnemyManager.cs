using UnityEngine;
using Pathfinding;
using System.Collections;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _animationDeathTime;

    private Animator _animator;
    private AIPath _aiPath;
    private EnemyModel _enemyModel;
    private CharacterController _characterController;
    private bool _isDeath;

    private GameObject _player;
    private AIDestinationSetter _destinationSetter;

    public event Action<EnemyManager> PushEvent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _aiPath = GetComponent<AIPath>();
        _enemyModel = GetComponent<EnemyModel>();
        _aiPath.maxSpeed = _speed;
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _player = Singelton<PlayerModel>.Instance.gameObject;
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        SetTarget();
    }

    private void OnDisable()
    {
        PushEvent = null;
    }

    private void Update()
    {
        _animator.SetFloat("hInput", _aiPath.velocity.x);
        _animator.SetFloat("vInput", _aiPath.velocity.z);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.TryGetComponent<PlayerInteractionManager>(out PlayerInteractionManager _))
            _animator.SetBool("isAttack", true);
        else
            _animator.SetBool("isAttack", false);
    }

    private void SetTarget() => _destinationSetter.target = _player.transform;

    private bool IsAnimationCanceled(string AnimationName)
    {
        if (AnimationName == null)
            return false;
        var check = _animator.GetCurrentAnimatorStateInfo(0);

        return check.IsName(AnimationName);
    }
    
    private IEnumerator DeathEnemy()
    {
        while(true) 
        {
            if (IsAnimationCanceled("Death")) 
            {
                _isDeath = false;
                _animator.SetBool("isDeath", _isDeath);
                _enemyModel.SetDefaultState();
                _characterController.excludeLayers = default;
                PushEvent?.Invoke(this);
                break;
            }
            yield return new WaitForSeconds(_animationDeathTime);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_enemyModel.GetDamage(damage) <= 0 && !_isDeath)
        {
            _destinationSetter.target = null;
            _isDeath = true;
            _characterController.excludeLayers = 65;
            _animator.SetBool("isDeath", _isDeath);
            StartCoroutine(DeathEnemy());
        }
    }
}
