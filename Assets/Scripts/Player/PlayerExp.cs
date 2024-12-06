using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            AddExperience(300);
        }
    }

    public void AddExperience(float amount)
    {
        stats.TotalExp += amount;
        stats.CurrentExp += amount;
        while (stats.CurrentExp >= stats.NextLevelExp)
        {
            stats.CurrentExp -= stats.NextLevelExp;
            NextLevel();
        }
    }

    private void NextLevel()
    {
        stats.Level++;
        stats.AttributePoints++;
        float currentExpRequired = stats.NextLevelExp;
        float newNextLevelExp = Mathf.Round(currentExpRequired + stats.NextLevelExp * (stats.ExpMultiplier / 100));
        stats.NextLevelExp = newNextLevelExp;
    }
}