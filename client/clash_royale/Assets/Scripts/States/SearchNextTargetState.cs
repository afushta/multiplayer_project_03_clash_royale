using UnityEngine;

[CreateAssetMenu(fileName = "SearchNextTargetState", menuName = "UnitStates/SearchNextTargetState")]
public class SearchNextTargetState : CharacterState
{
    public override void OnEnter() {}

    public override void OnExit() {}

    public override void Run()
    {
        if (_character.TryFindTarget(out Unit target))
        {
            _character.SetTarget(target);
            _character.SetState(CharacterStates.Move);
        }
    }
}
