using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private CreateEnemyPool _enemyPool;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if(!_enemyPool.ObjectPoolEnemy.ÑheckingForActive())
            _animator.SetBool("isOpen", true);
    }

}
