using UnityEngine;

public abstract class CharacterState : ScriptableObject
{
    protected Character _character;

    public virtual void Init(Character character)
    {
        _character = character;
    }

    public abstract void OnEnter();
    public abstract void Run();
    public abstract void OnExit();
}
