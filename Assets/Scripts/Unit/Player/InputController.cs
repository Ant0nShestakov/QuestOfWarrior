using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private BaseMap _inputActions;

    #region Movement
    public Vector2 MoveValue { get; private set; }
    public Vector2 LookValue { get; private set; }
    public float JumpValue { get; private set; }
    #endregion

    #region Attack
    public float BlockValue { get; private set; }
    public float AutoAttackValue { get; private set; }
    public float FirstSpecialAttackValue { get; private set; }
    public float SecondSpecialAttackValue { get; private set; }
    public float ThridSpecialAttackValue { get; private set; }
    public float FourthSpecialAttackValue { get; private set; }
    public float FifthSpecialAttackValue { get; private set; }
    public float SixSpecialAttackValue { get; private set; }
    public float SeventhSpecialAttackValue { get; private set; }
    public float EighthSpecialAttackValue { get; private set; }
    #endregion

    private void Awake()
    {
        _inputActions = new BaseMap();

        SubscribeMovement();
        SubscribeAttack();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void SubscribeMovement()
    {
        SubscribePerformMovementActions();
        SubscribeCancelMovementActions();
    }

    private void SubscribeAttack()
    {
        SubscribePerformAttackActions();
        SubscribeCancelAttackActions();
    }


    #region AttackActions
    private void SubscribePerformAttackActions()
    {
        _inputActions.Player.FirstSpecialAttack.performed += FirstSpecialAttack;
        _inputActions.Player.SecondSpecialAttack.performed += SecondSpecialAttack;
        _inputActions.Player.ThridSpecialAttack.performed += ThridSpecialAttack;
        _inputActions.Player.FourthSpecialAttack.performed += FourthSpecialAttack;
        _inputActions.Player.FifthSpecialAttack.performed += FifthSpecialAttack;
        _inputActions.Player.SixSpecialAttack.performed += SixSpecialAttack;
        _inputActions.Player.SeventhSpecialAttack.performed += SeventhSpecialAttack;
        _inputActions.Player.EighthSpecialAttack.performed += EighthSpecialAttack;
    }

    private void SubscribeCancelAttackActions()
    {
        _inputActions.Player.FirstSpecialAttack.canceled += FirstSpecialAttack;
        _inputActions.Player.SecondSpecialAttack.canceled += SecondSpecialAttack;
        _inputActions.Player.ThridSpecialAttack.canceled += ThridSpecialAttack;
        _inputActions.Player.FourthSpecialAttack.canceled += FourthSpecialAttack;
        _inputActions.Player.FifthSpecialAttack.canceled += FifthSpecialAttack;
        _inputActions.Player.SixSpecialAttack.canceled += SixSpecialAttack;
        _inputActions.Player.SeventhSpecialAttack.canceled += SeventhSpecialAttack;
        _inputActions.Player.EighthSpecialAttack.canceled += EighthSpecialAttack;
    }

    private void EighthSpecialAttack(InputAction.CallbackContext context)
    {
        EighthSpecialAttackValue = context.action.ReadValue<float>();
    }

    private void SeventhSpecialAttack(InputAction.CallbackContext context)
    {
        SeventhSpecialAttackValue = context.action.ReadValue<float>();
    }

    private void SixSpecialAttack(InputAction.CallbackContext context)
    {
        SixSpecialAttackValue = context.action.ReadValue<float>();
    }

    private void FifthSpecialAttack(InputAction.CallbackContext context)
    {
        FifthSpecialAttackValue = context.action.ReadValue<float>();
    }

    private void FourthSpecialAttack(InputAction.CallbackContext context)
    {
        FourthSpecialAttackValue = context.action.ReadValue<float>();
    }

    private void ThridSpecialAttack(InputAction.CallbackContext context)
    {
        ThridSpecialAttackValue = context.action.ReadValue<float>();
    }

    private void SecondSpecialAttack(InputAction.CallbackContext context)
    {
        SecondSpecialAttackValue = context.action.ReadValue<float>();
    }

    private void FirstSpecialAttack(InputAction.CallbackContext context)
    {
        FirstSpecialAttackValue = context.action.ReadValue<float>();
    }
    #endregion


    #region MovementActions
    private void SubscribePerformMovementActions()
    {
        _inputActions.Player.Move.performed += Move;
        _inputActions.Player.Jump.performed += Jump;
        _inputActions.Player.Look.performed += Look;
    }

    private void SubscribeCancelMovementActions()
    {
        _inputActions.Player.Move.canceled += Move;
        _inputActions.Player.Jump.canceled += Jump;
        _inputActions.Player.Look.canceled += Look;
    }

    private void Look(InputAction.CallbackContext context)
    {
        LookValue = context.action.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        JumpValue = context.action.ReadValue<float>();
    }

    private void Move(InputAction.CallbackContext context)
    {
        MoveValue = context.action.ReadValue<Vector2>();
    }
    #endregion

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}
