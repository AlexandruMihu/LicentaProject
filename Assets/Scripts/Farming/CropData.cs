using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropData : MonoBehaviour
{
    [Header("Basic Info")]
    public string cropName; 
    public Sprite icon; 

    [Header("Growth Settings")]
    public float growthTime; 
    public Sprite[] growthStages; 

    [Header("Harvest Settings")]
    public int harvestCount; 
    public int seedCost;
    public InventoryItem[] harvestedItem; 
}

