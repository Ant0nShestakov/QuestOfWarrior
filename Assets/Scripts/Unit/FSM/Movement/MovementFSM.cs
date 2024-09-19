using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class MovementFSM : IFSM
{
    private readonly Animator _animator;
    private readonly InputController _inputManager;
    private readonly PhysicsController _physicsController;

    private readonly IActionStateVisitor _fSMVisitor;

    private ActionState _currentState;

    private Dictionary<string, ActionState> _states;

    public bool IsGrounded => _physicsController.IsGrounded;

    public IReadOnlyDictionary<string, ActionState> States => _states;

    public Animator Animator => _animator;

    public IActionStateVisitor Visitor => _fSMVisitor;

    public MovementFSM(UnitView unitView, IActionStateVisitor[] fSMVisitor)
    {
        _animator = unitView.GetComponent<Animator>();
        _inputManager = unitView.GetComponent<InputController>();
        _physicsController = unitView.GetComponent<PhysicsController>();

        _fSMVisitor = fSMVisitor.Where(visitor => visitor is MovementFSMVisitor).FirstOrDefault();

        Initialize();

        _currentState = _states.GetValueOrDefault(nameof(WalkState));
    }

    private void Initialize()
    {
        _states = new Dictionary<string, ActionState>
        {
            { nameof(WalkState), new WalkState(_inputManager) },
            { nameof(RunState), new RunState(_inputManager) },
            { nameof(FallState), new FallState(_inputManager) },
            { nameof(CrouchState), new CrouchState(_inputManager) },
        };
    }

    public void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(ActionState actionState)
    {
        _currentState.ExitState(this);

       _currentState = actionState ?? throw new NullReferenceException();

        _currentState.EnterState(this); 
    }
}