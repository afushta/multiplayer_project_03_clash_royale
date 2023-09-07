using UnityEngine;

[CreateAssetMenu(fileName = "SearchNextTargetState", menuName = "UnitStates/SearchNextTargetState")]
public class SearchNextTargetState : CharacterState
{
    public override void OnEnter() {}

    public override void OnExit() {}

    public override void Run()
    {
        Unit target = UnitsCache.Instance.GetNearestUnit(_character.transform.position, _character.EnemiesOwner);
        if (target)
        {
            _character.SetTarget(target);
            _character.SetState(CharacterStates.Chase);
        }
    }
}
