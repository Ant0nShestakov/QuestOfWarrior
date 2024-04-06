using UnityEngine;

public class CharacterControllerManagerOnSpecialAttack : MonoBehaviour
{
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void MoveUpCollider(float value) => _characterController.height += value;

    public void MoveDownCollider(float value) => _characterController.height -= value;
}
