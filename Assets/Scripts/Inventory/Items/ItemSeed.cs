using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSeed", menuName = "Items/Seeds")]

public class ItemSeed : InventoryItem
    {
        [Header("Seed Properties")]
        public string cropName;
        public Sprite cropIcon;
        public Sprite[] growthStages; 
        public float growthTime;      
        public InventoryItem harvestItem; 
        public int harvestCount; 
    }
