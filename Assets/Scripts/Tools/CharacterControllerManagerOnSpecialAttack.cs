using UnityEngine;

public class CharacterControllerManagerOnSpecialAttack : MonoBehaviour
{
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void MoveUpCollider(float value)
    {
        _characterController.height += value;
    }

    public void MoveDownCollider(float value)
    {
        _characterController.height -= value;
    }
}
