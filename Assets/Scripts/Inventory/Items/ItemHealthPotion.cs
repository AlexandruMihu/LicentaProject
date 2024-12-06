using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemHealthPotion", menuName = "Items/Health Potion")]
public class ItemHealthPotion : InventoryItem
{
    [Header("Config")]
    public float HealthValue;

    public override bool UseItem()
    {
        if (GameManager.Instance.Player.PlayerHealth.CanRestoreHealth())
        {
            GameManager.Instance.Player.PlayerHealth.RestoreHealth(HealthValue);
            return true;
        }
        return false;
    }
}

