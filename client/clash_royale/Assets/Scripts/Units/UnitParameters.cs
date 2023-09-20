using System;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { None, Melee, Range }
[Flags] public enum UnitType { None = 0, Tower = 1, Ground = 2, Air = 4, All = ~0 }

public class UnitParameters : MonoBehaviour
{
    [field: SerializeField] public float ModelRadius { get; private set; } = 1f;
    [field: SerializeField] public UnitType UnitType { get; private set; }
    [field: SerializeField] public float Speed { get; private set; } = 4f;

    [Header("Attack Parameters")]
    [SerializeField] private List<AttackPriority> _attackPriorities;
    [field: SerializeField] public AttackType AttackType { get; private set; }
    [field: SerializeField] public Projectile ProjectilePrefab { get; private set; }
    [field: SerializeField] public float ProjectileSpeed { get; private set; } = 5f;
    [field: SerializeField] public Transform ProjectileSpawnPoint { get; private set; }
    [field: SerializeField] public int AttackDamage { get; private set; } = 1;
    [field: SerializeField] public float AttackInterval { get; private set; } = 1f;
    [SerializeField] private float AttackRange = 0.2f;

    public float AttackRangeMin => AttackRange + ModelRadius;
    public float AttackRangeMax => AttackRange + Mathf.Max(0.1f, AttackRange * 0.1f) + ModelRadius;
    public AttackPriority[] AttackPriorities => _attackPriorities.ToArray();
}

[Serializable]
public struct AttackPriority
{
    [SerializeField] private UnitType _targetType;
    [SerializeField] private float _detectRange;

    public readonly UnitType Type => _targetType;
    public readonly float Distance => _detectRange;
}
