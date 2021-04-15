using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HealthSystem
{
    public static void TakeDamage(float amount, Entity entity)
    {
        var currentHealth = entity.HP;

        if (currentHealth - amount <= 0.0f)
        {
            OnDeath();
            if (currentHealth - amount < 0.0f)
                amount = (float)OnOverkill(amount, currentHealth);
        }
        currentHealth -= amount;

        OnHit((int)amount);

        entity.ChangeHealth();

        entity.HP = currentHealth;
    }
    private static void OnDeath()
    {
        var target = EntityManager.TargetEntity;

        CommandCreator.CurrentAttackCommand.HasDied = true;

        UI.OnShowText?.Invoke(target.name + " is death");
    }
    private static float OnOverkill(float damage, float currentHealth)
    {
        var damagePoints = currentHealth;

        CommandCreator.CurrentAttackCommand.DeniedDamage = damage - damagePoints;

        return damagePoints;
    }
    private static void OnHit(int damage)
    {
        var target = EntityManager.TargetEntity;
        var executor = EntityManager.ExecutorEntity;
    }
}
