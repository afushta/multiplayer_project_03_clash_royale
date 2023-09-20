using System.Collections.Generic;
using UnityEngine;

public class UnitsCache : Manager<UnitsCache>
{
    private List<Unit> _playerUnits = new ();
    private List<Unit> _enemyUnits = new ();

    public void AddUnit(Unit unit)
    {
        switch (unit.Owner)
        {
            case Owner.Player:
                _playerUnits.Add(unit);
                break;
            case Owner.Enemy:
                _enemyUnits.Add(unit);
                break;
            default:
                break;
        }
    }

    public void RemoveUnit(Unit unit)
    {
        switch (unit.Owner)
        {
            case Owner.Player:
                _playerUnits.Remove(unit);
                break;
            case Owner.Enemy:
                _enemyUnits.Remove(unit);
                break;
            default:
                break;
        }
    }

    public Unit GetNearestUnit(Vector3 position, Owner unitOwner, UnitType type, float maxDistance = float.PositiveInfinity)
    {
        List<Unit> units = unitOwner == Owner.Enemy ? _enemyUnits : _playerUnits;

        float minDistance = maxDistance;
        Unit nearestEnemy = null;
        foreach (Unit enemy in units)
        {
            if (!enemy) continue;
            if ((enemy.Parameters.UnitType & type) == UnitType.None) continue;

            float distance = Vector3.Distance(position, enemy.transform.position);
            if (distance < minDistance)
            {
                nearestEnemy = enemy;
                minDistance = distance;
            }
        }

        return nearestEnemy;
    }
}
