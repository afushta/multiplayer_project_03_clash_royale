using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character : Unit
{
    [SerializeField] private CharacterState _defaultStateBase;
    [SerializeField] private CharacterState _chaseStateBase;
    [SerializeField] private CharacterState _attackStateBase;

    private CharacterState _defaultState;
    private CharacterState _chaseState;
    private CharacterState _attackState;
    private CharacterState _currentState;
    private CharacterStates _currentStateName = CharacterStates.None;

    public Unit Target { get; private set; }
    public float DistanceToTarget => Vector3.Distance(transform.position, Target.transform.position) - Target.Parameters.ModelRadius;
    public Owner EnemiesOwner { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _defaultState = Instantiate(_defaultStateBase);
        _defaultState.Init(this);

        _chaseState = Instantiate(_chaseStateBase);
        _chaseState.Init(this);

        _attackState = Instantiate(_attackStateBase);
        _attackState.Init(this);

        SetState(CharacterStates.Default);

        EnemiesOwner = Owner == Owner.Player ? Owner.Enemy : Owner.Player;
    }

    public void SetState(CharacterStates newState)
    {
        if (_currentStateName == newState) return;

        if (_currentState) _currentState.OnExit();

        Debug.Log("Switch to state " + newState);
        switch (newState)
        {
            case CharacterStates.Default:
                _currentState = _defaultState;
                break;
            case CharacterStates.Chase:
                _currentState = _chaseState;
                break;
            case CharacterStates.Attack:
                _currentState = _attackState;
                break;
            default:
                Debug.LogError($"Unsupported state {newState}");
                break;
        }

        if (_currentState) _currentState.OnEnter();
    }

    private void Update()
    {
        _currentState.Run();
    }

    public void SetTarget(Unit enemy)
    {
        Target = enemy;
    }
}

public enum CharacterStates { None, Default, Chase, Attack }
