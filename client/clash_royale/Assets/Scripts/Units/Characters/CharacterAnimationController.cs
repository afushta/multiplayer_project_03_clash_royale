using UnityEngine;
using UnityEngine.Events;

public class CharacterAnimationController : MonoBehaviour
{
    private const string PARAM_STATE = "State";
    private const string PARAM_ATTACK_SPEED = "AttackSpeed";
    private const string PARAM_MOVE_SPEED = "MoveSpeed";

    [SerializeField] private Animator animator;

    public UnityEvent OnAttackTrigger;

    public void Init(Character character)
    {
        animator.SetFloat(PARAM_ATTACK_SPEED, 1f / character.Parameters.AttackInterval);
        animator.SetFloat(PARAM_MOVE_SPEED, 1f);
    }

    public void SetState(CharacterStates state)
    {
        animator.SetInteger(PARAM_STATE, (int)state);
    }

    public void TriggerAttack()
    {
        OnAttackTrigger?.Invoke();
    }
}
