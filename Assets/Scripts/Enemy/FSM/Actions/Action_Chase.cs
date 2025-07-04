using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Chase : FSMAction
{
    [Header("Config")]
    [SerializeField] private float chaseSpeed;

    private EnemyBrain enemyBrain;
    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        ChasePlayer();
    }
    private void ChasePlayer()
    {
        if (enemyBrain.Player == null) return;
        Vector3 directionToPlayer = enemyBrain.Player.position - transform.position;
        if (directionToPlayer.magnitude >= 1.3)
        {
            transform.Translate(directionToPlayer.normalized*chaseSpeed*Time.deltaTime);
        }
    }
}
