using UnityEngine;

public class PlayerAimManager : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private float _sensetivity = 1;
    [SerializeField] private float _vClampMax;
    [SerializeField] private float _vClampMin;

    private PlayerModel _playerModel;
    private float _hInput;
    private float _vInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerModel = GetComponent<PlayerModel>();
    }

    private void Update()
    {
        if (!_playerModel.IsNotLocked)
        {
            _hInput += Input.GetAxis("Mouse X") * _sensetivity;
            _vInput += Input.GetAxis("Mouse Y") * _sensetivity;

            _vInput = Mathf.Clamp(_vInput, _vClampMin, _vClampMax);
        }
    }

    private void LateUpdate()
    {
        if (!_playerModel.IsNotLocked)
        {
            //_cameraPosition.localEulerAngles = new Vector3(-_vInput, _cameraPosition.localEulerAngles.y, _cameraPosition.localEulerAngles.z);

            //this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, _hInput, transform.eulerAngles.z);

            Quaternion newCameraRotation = Quaternion.Euler(-_vInput, _cameraPosition.localEulerAngles.y, _cameraPosition.localEulerAngles.z);
            _cameraPosition.localRotation = newCameraRotation;

            Quaternion newPlayerRotation = Quaternion.Euler(this.transform.eulerAngles.x, _hInput, transform.eulerAngles.z);
            transform.rotation = newPlayerRotation;
        }
    }
}
