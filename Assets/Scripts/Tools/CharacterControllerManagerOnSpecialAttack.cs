using UnityEngine;

public class CharacterControllerManagerOnSpecialAttack : MonoBehaviour
{
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController =GetComponent<CharacterController>();
    }

    public void MoveCollider(float value)
    {
        _characterController.center = new Vector3(0, value, 0);
    }
}
