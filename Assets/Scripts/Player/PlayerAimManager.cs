using UnityEngine;

public class PlayerAimManager : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private float sensetivity = 1;
    [SerializeField] private float _vClampMax;
    [SerializeField] private float _vClampMin;

    private PlayerModel _playerModel;
    private float _hInput;
    private float _vInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerModel = GetComponent<PlayerModel>();
    }

    void Update()
    {
        if (!_playerModel.LockState)
        {
            _hInput += Input.GetAxis("Mouse X") * sensetivity;
            _vInput += Input.GetAxis("Mouse Y") * sensetivity;

            _vInput = Mathf.Clamp(_vInput, _vClampMin, _vClampMax);
        }
    }

    private void LateUpdate()
    {
        if (!_playerModel.LockState)
        {
            _cameraPosition.localEulerAngles = new Vector3(-_vInput, _cameraPosition.localEulerAngles.y, _cameraPosition.localEulerAngles.z);
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, _hInput, transform.eulerAngles.z);
        }
    }
}
