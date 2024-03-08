using UnityEngine;
using Pathfinding;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _animationDeathTime;

    private CreateEnemyPool _enemyPool;
    private Animator _animator;
    private AIPath _aiPath;
    private EnemyModel _enemyModel;
    private bool _isDeath;

    private AudioSource _audioSource;

    private GameObject _player;
    private AIDestinationSetter _destinationSetter;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _aiPath = GetComponent<AIPath>();
        _enemyModel = GetComponent<EnemyModel>();
        _aiPath.maxSpeed = _speed;
        _enemyPool = Singelton<CreateEnemyPool>.Instance;
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _player = GameObject.FindWithTag("Player");
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    private void OnEnable()
    {
        SetTarget();
    }

    private void Update()
    {
        _animator.SetFloat("hInput", _aiPath.velocity.x);
        _animator.SetFloat("vInput", _aiPath.velocity.z);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.TryGetComponent<PlayerInteractionManager>(out PlayerInteractionManager pl))
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
                _enemyPool.ObjectPoolEnemy.ReturnObjectToPool(this);
                break;
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_enemyModel.GetDamage(damage) <= 0 && !_isDeath)
        {
            _isDeath = true;
            _animator.SetBool("isDeath", _isDeath);
            _destinationSetter.target = null;
            StartCoroutine(DeathEnemy());
        }
    }

    public void PlayWalkSound(int indexPan)
    {
        _audioSource.panStereo = indexPan;
        _audioSource.Play();
    }
}
