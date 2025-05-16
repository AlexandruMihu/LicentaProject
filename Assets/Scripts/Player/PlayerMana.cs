using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public float CurrentMana {  get; private set; }


    private void Start()
    {
        ResetMana();
    }

    public void UseMana(float amount)
    {
        stats.Mana = Mathf.Max(0, stats.Mana - amount);
        CurrentMana = stats.Mana;
        stats.SaveStats();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            UseMana(1);
        }
    }

    public void RestoreMana(float amount)
    {
        stats.Mana += amount;
        stats.Mana = Mathf.Min(stats.Mana,stats.MaxMana);
        stats.SaveStats() ;
    }

    public bool CanRestoreMana()
    {
        return stats.Mana > 0 && stats.Mana < stats.MaxMana;
    }

    public void ResetMana()
    {
        CurrentMana = stats.MaxMana;
    }
}
