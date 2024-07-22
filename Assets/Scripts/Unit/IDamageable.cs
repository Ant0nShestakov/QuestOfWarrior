using System;

public interface IDamageable
{
    public event Action UpdateStatsEvent;
    public void ApplyDamage(float damage);
}