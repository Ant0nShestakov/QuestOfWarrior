using System;

public interface IDamageable
{
    public event Action<float> ApplyDamageEvent;
    public void ApplyDamage(float damage);
}