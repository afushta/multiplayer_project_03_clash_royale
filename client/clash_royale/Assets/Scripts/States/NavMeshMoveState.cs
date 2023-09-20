using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "NavMeshMoveState", menuName = "UnitStates/NavMeshMoveState")]
public class NavMeshMoveState : CharacterState
{
    private NavMeshAgent _agent;

    public override void Init(Character character)
    {
        base.Init(character);

        _agent = _character.GetComponent<NavMeshAgent>();
        _agent.speed = _character.Parameters.Speed;
        _agent.radius = _character.Parameters.ModelRadius;
        _agent.stoppingDistance = _character.Parameters.AttackRangeMin;
    }

    public override void OnEnter()
    {
        UpdateDestination();
        _agent.isStopped = false;
    }

    public override void OnExit()
    {
        _agent.isStopped = true;
    }

    public override void Run()
    {
        if (_character.Target == null)
        {
            _character.SetState(CharacterStates.Default);
            return;
        }

        UpdateDestination();

        if (_character.DistanceToTarget <= _character.Parameters.AttackRangeMin)
        {
            _character.SetState(CharacterStates.Attack);
        }
    }

    private void UpdateDestination()
    {
        if (_character.TryFindTarget(out Unit target) && target != _character.Target)
        {
            _character.SetTarget(target);
        }

        _agent.SetDestination(_character.Target.GetClosestPoint(_character.transform.position));
    }
}
