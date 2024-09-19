using UnityEngine;

public sealed class AimHandler : IHandler
{
    private readonly Transform _cameraTransform;
    private readonly Transform _rootTransform;

    private readonly Vector2 _clampAngle;

    private float _mouseX;
    private float _mouseY;

    private readonly InputController _inputController;

    public AimHandler(Transform cameraTransform, Controller controller)
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cameraTransform = cameraTransform;

        _inputController = controller.GetComponent<InputController>();
        _rootTransform = controller.transform;

        _clampAngle = new Vector2 (_inputController.MinClampAngle, _inputController.MaxClampAngle);
    }

    public void Update()
    {
        _mouseX += _inputController.LookValue.x * Time.deltaTime;
        _mouseY -= _inputController.LookValue.y * Time.deltaTime;

        _mouseY = Mathf.Clamp(_mouseY, _clampAngle.x, _clampAngle.y);

        _cameraTransform.localRotation = Quaternion.Euler(_mouseY, 0, 0);
        _rootTransform.rotation = Quaternion.Euler(0, _mouseX, 0);
    }
}
