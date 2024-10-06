using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class AttackFSM : IFSM
{
    private readonly Animator _animator;
    private readonly InputController _inputManager;
    private readonly PhysicsController _physicsController;

    private readonly IAttackStateVisitor _fSMVisitor;

    private ActionState _currentState;

    private Dictionary<string, ActionState> _states;

    public bool IsGrounded => _physicsController.IsGrounded;

    public IReadOnlyDictionary<string, ActionState> States => _states;

    public Animator Animator => _animator;

    public IIdleStateVisitor Visitor => _fSMVisitor;

    public AttackFSM(UnitView unitView, IAttackStateVisitor fSMVisitor)
    {
        _animator = unitView.GetComponent<Animator>();
        _inputManager = unitView.GetComponent<InputController>();
        _physicsController = unitView.GetComponent<PhysicsController>();

        _fSMVisitor = fSMVisitor;

        Initialize();

        _currentState = _states.GetValueOrDefault(nameof(IdleAttack)) ?? throw new NullReferenceException();
    }

    private void Initialize()
    {
        _states = new Dictionary<string, ActionState>
        {
            { nameof(IdleAttack), new IdleAttack(_inputManager) },
            { nameof(AutoAttack), new AutoAttack(_inputManager) },
            { nameof(Block), new Block(_inputManager) },
            { nameof(FirstSpecialAttack), new FirstSpecialAttack(_inputManager) },
            { nameof(SecondSpecialAttack), new SecondSpecialAttack(_inputManager) },
            { nameof(ThridSpecialAttack), new ThridSpecialAttack(_inputManager) },
            { nameof(FourthSpecialAttack), new FourthSpecialAttack(_inputManager) },
            { nameof(FifthSpecialAttack), new FifthSpecialAttack(_inputManager) },
            { nameof(SixSpecialAttack), new SixSpecialAttack(_inputManager) },
            { nameof(SeventhSpecialAttack), new SeventhSpecialAttack(_inputManager) }
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