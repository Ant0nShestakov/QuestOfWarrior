using UnityEngine;
using Zenject;

public class DoorManager : MonoBehaviour
{
    [Inject] private IObjectPool<EnemyManager> _enemyPool;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if(!_enemyPool.ÑheckingForActive())
            _animator.SetBool("isOpen", true);
    }
}
