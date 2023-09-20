using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackState", menuName = "UnitStates/RangedAttackState")]
public class RangedAttackState : AttackState
{
    protected override void Attack()
    {
        Transform spawner = _character.Parameters.ProjectileSpawnPoint;

        Projectile projectile = Instantiate(_character.Parameters.ProjectilePrefab, spawner.position, spawner.rotation);
        projectile.Init(_character.Target, _character.Parameters.ProjectileSpeed, _character.Parameters.AttackDamage);
    }
}
