using UnityEngine;

public abstract class DestructableObject : MonoBehaviour
{
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private int _maxHealth = 10;

    public int Health { get; private set; }
    public int MaxHealth => MaxHealth;

    protected virtual void Start()
    {
        Health = _maxHealth;
        if (healthbar) healthbar.Init(_maxHealth);
    }

    private void SetHealth(int value)
    {
        Health = value;
        
        if (healthbar) healthbar.UpdateValue(Health, _maxHealth);
    }

    public virtual void ApplyDamage(int value)
    {
        SetHealth(Mathf.Max(Health - value, 0));
        
        if (Health == 0) Destroy();
    }

    public virtual void ApplyHeal(int value)
    {
        SetHealth(Mathf.Min(Health + value, _maxHealth));
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
