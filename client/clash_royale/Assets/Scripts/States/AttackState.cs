using UnityEngine;

[CreateAssetMenu(fileName = "AttackState", menuName = "UnitStates/AttackState")]
public class AttackState : CharacterState
{
    // private float _timeFromLastAttack;

    public override void OnEnter()
    {
        _character.transform.LookAt(_character.Target.transform.position);
        _character.AnimationController.OnAttackTrigger.AddListener(Attack);
        // _timeFromLastAttack = 0f;
    }

    public override void OnExit()
    {
        _character.AnimationController.OnAttackTrigger.RemoveListener(Attack);
    }

    public override void Run()
    {
        if (_character.Target == null)
        {
            _character.SetState(CharacterStates.Default);
            return;
        }

        if (_character.DistanceToTarget > _character.Parameters.AttackRangeMax)
        {
            _character.SetState(CharacterStates.Move);
            return;
        }

        /*_timeFromLastAttack += Time.deltaTime;
        if (_timeFromLastAttack >= _character.Parameters.AttackInterval)
        {
            _timeFromLastAttack -= _character.Parameters.AttackInterval;
            Attack();
        }*/
    }

    protected virtual void Attack()
    {
        Debug.Log($"{_character.name} attack target {_character.Target}");
        _character.Target.ApplyDamage(_character.Parameters.AttackDamage);
    }
}
