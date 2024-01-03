using Pathfinding;
using UnityEngine;

public class SetPlayerTransfrom : MonoBehaviour
{
    private GameObject _player;
    private AIDestinationSetter _destinationSetter;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _destinationSetter = GetComponent<AIDestinationSetter>();
        SetTarget();
    }

    private void SetTarget() => _destinationSetter.target = _player.transform;
}
