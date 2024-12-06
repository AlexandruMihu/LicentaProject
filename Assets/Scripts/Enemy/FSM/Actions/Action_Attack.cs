using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBtwAttacks;

    private EnemyBrain enemyBrain;
    private float timer;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }
    public override void Act()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (enemyBrain.Player == null) return;
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            IDamageable player = enemyBrain.Player.GetComponent<IDamageable>();
            player.TakeDamage(damage);
            timer = timeBtwAttacks;

        }
    }
}
