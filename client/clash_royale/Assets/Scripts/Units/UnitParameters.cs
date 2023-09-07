using UnityEngine;

public class UnitParameters : MonoBehaviour
{
    [field: SerializeField] public float ModelRadius { get; private set; } = 1f;
    [field: SerializeField] public float Speed { get; private set; } = 4f;
    [field: SerializeField] public int AttackDamage { get; private set; } = 1;
    [field: SerializeField] public float AttackInterval { get; private set; } = 1f;
    [SerializeField] private float attackRangeMin = 0.2f;
    [SerializeField] private float attackRangeMax = 0.3f;

    public float AttackRangeMin => attackRangeMin + ModelRadius;
    public float AttackRangeMax => attackRangeMax + ModelRadius;
}
