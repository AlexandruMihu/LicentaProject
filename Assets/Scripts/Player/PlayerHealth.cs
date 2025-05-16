using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if(stats.Health<=0)
        {
            PlayerDead();
        }
    }

    public void TakeDamage(float damage)
    {
        if (stats.Health <= 0) return;

        stats.Health -= damage;
        DamageManager.Instance.ShowDamageText(damage,transform);

        if (stats.Health <= 0)
        {
            stats.Health = 0;
            PlayerDead();
        }
        stats.SaveStats();
    }

    public void RestoreHealth(float amount) 
    {
        stats.Health += amount;
        stats.Health = Mathf.Min(stats.Health, stats.MaxHealth);
        stats.SaveStats();
    }

    public bool CanRestoreHealth()
    {
        return stats.Health > 0 && stats.Health < stats.MaxHealth;
    }

    private void PlayerDead()
    {
        playerAnimations.SetDeadAnimation();
    }
}
