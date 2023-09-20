using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    private Unit _target;
    private float _speed;
    private int _damage;

    private float DistanceToTarget => Vector3.Distance(transform.position, _target.transform.position);

    public void Init(Unit target, float speed, int damage)
    {
        _target = target;
        _speed = speed;
        _damage = damage;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy();
            return;
        }

        transform.LookAt(_target.transform);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

        if (DistanceToTarget <= float.Epsilon)
        {
            _target.ApplyDamage(_damage);
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
