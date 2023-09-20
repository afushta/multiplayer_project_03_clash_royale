using UnityEngine;

public enum Owner { Player, Enemy }

[RequireComponent(typeof(UnitParameters))]
public class Unit : DestructableObject
{
    [SerializeField] private UnitSkin _skin;
    [SerializeField] private Collider _collider;

    [field: SerializeField] public Owner Owner { get; private set; }
    public UnitParameters Parameters { get; private set; }

    protected virtual void Awake()
    {
        Parameters = GetComponent<UnitParameters>();
        _skin?.SetSkin(Owner);
    }

    protected override void Start()
    {
        base.Start();
        UnitsCache.Instance.AddUnit(this);
    }

    private void OnDestroy()
    {
        UnitsCache.Instance.RemoveUnit(this);
    }

    private void OnValidate()
    {
        _skin?.SetSkin(Owner);
    }

    public Vector3 GetClosestPoint(Vector3 from)
    {
        if (_collider) return _collider.ClosestPointOnBounds(from);
        else return transform.position;
    }
}
