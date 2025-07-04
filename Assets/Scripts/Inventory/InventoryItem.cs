using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Potion,
    Scroll,
    Ingredients,
    Treasure,
    Seed
}

[CreateAssetMenu(menuName ="Items/Item")]
public class InventoryItem : ScriptableObject
{
    [Header("Config")]
    public string ID;
    public string Name;
    public Sprite Icon;
    [TextArea] public string Description;

    [Header("Info")]
    public ItemType ItemType;
    public bool isConsumable;
    public bool isStackable;
    public int MaxStack;

    [HideInInspector] public int Quantity;

    public InventoryItem CopyItem()
    {
        InventoryItem copy = Instantiate(this);
        return copy;
    }

    public virtual bool UseItem()
    {
        return true;
    }

    public virtual void EquipItem() { }
    public virtual void RemoveItem() { }
}
