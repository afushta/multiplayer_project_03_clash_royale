using UnityEngine;

public enum Owner { Player, Enemy }

[RequireComponent(typeof(UnitParameters))]
public class Unit : DestructableObject
{
    [field: SerializeField] public Owner Owner { get; private set; }
    public UnitParameters Parameters { get; private set; }

    protected virtual void Awake()
    {
        Parameters = GetComponent<UnitParameters>();
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
}
