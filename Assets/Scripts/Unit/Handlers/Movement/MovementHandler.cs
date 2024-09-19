using UnityEngine;

public sealed class MovementHandler : IHandler
{
    private readonly UnitModel _unit;
    private readonly UnitView _view;

    private readonly InputController _inputManager;

    private readonly PhysicsController _characterController;
    private readonly Transform _transform;

    private Vector3 _direction;

    public MovementHandler(UnitModel unit, Controller controller)
    {
        _unit = unit;
        _inputManager = controller.GetComponent<InputController>();
        _characterController = controller.GetComponent<PhysicsController>();
        _view = controller.GetComponent<UnitView>();

        _transform = controller.transform;
    }

    public void Update()
    {
        if (_characterController.IsGrounded)
        {
            SetMoveDirection();

            if (_inputManager.JumpValue > 0)
                Jump();
        }

        _characterController.Move(_direction, _unit.CurrentMass);

        _view.AnimateMovement(_inputManager.MoveValue);
    }

    private void SetMoveDirection()
    {
        Vector3 inputDirection = new(_inputManager.MoveValue.x, 0, _inputManager.MoveValue.y);
        inputDirection = _transform.TransformDirection(inputDirection);

        _direction = _unit.CurrentSpeed * inputDirection.normalized;
    }

    private void Jump() =>
        _characterController.Jump(_unit.CurrentJumpForce);
}
