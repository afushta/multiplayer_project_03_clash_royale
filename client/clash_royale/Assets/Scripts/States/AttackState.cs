using UnityEngine;

[CreateAssetMenu(fileName = "AttackState", menuName = "UnitStates/AttackState")]
public class AttackState : CharacterState
{
    private float _timeFromLastAttack;

    public override void OnEnter()
    {
        _character.transform.LookAt(_character.Target.transform.position);
        _timeFromLastAttack = 0f;
    }

    public override void OnExit() {}

    public override void Run()
    {
        if (_character.Target == null)
        {
            _character.SetState(CharacterStates.Default);
            return;
        }

        if (_character.DistanceToTarget > _character.Parameters.AttackRangeMax)
        {
            _character.SetState(CharacterStates.Chase);
            return;
        }

        _timeFromLastAttack += Time.deltaTime;
        if (_timeFromLastAttack >= _character.Parameters.AttackInterval)
        {
            _timeFromLastAttack -= _character.Parameters.AttackInterval;
            Debug.Log($"{_character.name} attack target {_character.Target}");
            _character.Target.ApplyDamage(_character.Parameters.AttackDamage);
        }
    }
}
