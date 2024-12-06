using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class EnemyHealth : MonoBehaviour, IDamageable
{
    public static event Action onEnemyDeadEvent;

    [Header("Config")]
    [SerializeField] private float health;

    public float CurrentHealth { get; private set; }

    private Animator animator;
    private Rigidbody2D rigidBody2D;
    private EnemyBrain enemyBrain;
    private EnemyLoot enemyLoot;
    private EnemySelector enemySelector;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        enemyBrain = GetComponent<EnemyBrain>();
        enemyLoot = GetComponent<EnemyLoot>();
        enemySelector = GetComponent<EnemySelector>();
    }

    private void Start()
    {
        CurrentHealth = health;
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if(CurrentHealth < 0 )
        {
            DisableEnemy();
            QuestManager.Instance.AddProgress("Kill2Enemies",1);
            QuestManager.Instance.AddProgress("Kill3Enemies",1);
            QuestManager.Instance.AddProgress("Kill4Enemies",1);
        }
        else
        {
            DamageManager.Instance.ShowDamageText(amount, transform);
        }
    }

    private void DisableEnemy()
    {
        animator.SetTrigger("Dead");
        enemyBrain.enabled = false;
        enemySelector.NoSelectionCallback();
        rigidBody2D.bodyType = RigidbodyType2D.Static;
        onEnemyDeadEvent?.Invoke();
        GameManager.Instance.AddPlayerExp(enemyLoot.ExpDrop);
    }
}
