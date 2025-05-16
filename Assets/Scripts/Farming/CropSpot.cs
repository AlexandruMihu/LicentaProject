using System;
using System.Collections;
using UnityEngine;

public class CropSpot : MonoBehaviour
{
    [Header("Crop Data")]
    private CropData cropData;
    private ItemSeed currentSeed;
    private float growthTimer;
    private bool isPlanted = false;
    private bool canHarvest = false;

    [Header("Visuals")]
    [SerializeField] private SpriteRenderer cropSpriteRenderer;
    [SerializeField] private GameObject plantInteractionBox;
    [SerializeField] private GameObject harvestInteractionBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FarmingManager.Instance.CropSpotSelected = this;
        }

        if (!isPlanted)
        {
            if (InventoryUI.Instance != null && InventoryUI.Instance.CurrentSlot != null)
            {
                int index = InventoryUI.Instance.CurrentSlot.Index;

                if (Inventory.Instance != null && index >= 0 && index < Inventory.Instance.InventoryItems.Length)
                {
                    InventoryItem selectedItem = Inventory.Instance.InventoryItems[index];

                   if (selectedItem != null && selectedItem.ItemType == ItemType.Seed)
                    {
                        plantInteractionBox.SetActive(true);
                    }
                }
            }
        }

        if (canHarvest)
        {
            harvestInteractionBox.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            plantInteractionBox.SetActive(false);
            harvestInteractionBox.SetActive(false);
        }
    }

    public void PlantSeed(ItemSeed seed)
    {
        if (isPlanted) return;

        plantInteractionBox.SetActive(false);

        currentSeed = seed;
        isPlanted = true;
        growthTimer = 0f;

        cropData = ScriptableObject.CreateInstance<CropData>();
        cropData.cropName = seed.cropName;
        cropData.icon = seed.cropIcon;
        cropData.growthTime = seed.growthTime;
        cropData.growthStages = seed.growthStages;
        cropData.harvestCount = seed.harvestCount;
        cropData.harvestedItem = new InventoryItem[] { seed.harvestItem };

        cropSpriteRenderer.sprite = cropData.growthStages[0];
        StartCoroutine(GrowCrop());
    }

    private IEnumerator GrowCrop()
    {
        while (growthTimer < cropData.growthTime)
        {
            growthTimer += Time.deltaTime;

            int stageIndex = Mathf.FloorToInt((growthTimer / cropData.growthTime) * cropData.growthStages.Length - 1);
            cropSpriteRenderer.sprite = cropData.growthStages[Mathf.Clamp(stageIndex, 0, cropData.growthStages.Length - 2)];
            
            yield return null;
        }

        canHarvest = true;
        cropSpriteRenderer.sprite = cropData.growthStages[^1];
    }

    public void HarvestCrop()
    {
        if (!isPlanted || growthTimer < cropData.growthTime) return;
        
        Inventory.Instance.AddItem(cropData.harvestedItem[0], cropData.harvestCount);
      
        canHarvest = false;
        isPlanted = false;
        cropData = null;
        cropSpriteRenderer.sprite = null;
        harvestInteractionBox.SetActive(false);

        QuestManager.Instance.AddProgress("Harvest1Plant", 1);
        QuestManager.Instance.AddProgress("Harvest2Plants", 1);
    }
}
