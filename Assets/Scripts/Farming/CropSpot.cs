using System.Collections;
using UnityEngine;

public class CropSpot : MonoBehaviour
{
    [Header("Crop Data")]
    private CropData cropData; 
    private ItemSeed currentSeed; 
    private float growthTimer; 
    private bool isPlanted = false;

    [Header("Visuals")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void PlantSeed(ItemSeed seed)
    {
        if (isPlanted) return; 

        currentSeed = seed;
        isPlanted = true;
        growthTimer = 0f;

        cropData = new CropData
        {
            cropName = seed.cropName,
            icon = seed.cropIcon,
            growthTime = seed.growthTime,
            growthStages = seed.growthStages,
            harvestCount = seed.harvestCount,
            harvestedItem = new InventoryItem[] { seed.harvestItem }
        };

        spriteRenderer.sprite = cropData.growthStages[0];
        StartCoroutine(GrowCrop());
    }

    private IEnumerator GrowCrop()
    {
        while (growthTimer < cropData.growthTime)
        {
            growthTimer += Time.deltaTime;

            int stageIndex = Mathf.FloorToInt((growthTimer / cropData.growthTime) * cropData.growthStages.Length);
            spriteRenderer.sprite = cropData.growthStages[Mathf.Clamp(stageIndex, 0, cropData.growthStages.Length - 1)];

            yield return null;
        }

        spriteRenderer.sprite = cropData.growthStages[^1];
    }

    public void HarvestCrop()
    {
        if (!isPlanted || growthTimer < cropData.growthTime) return;

        for (int i = 0; i < cropData.harvestCount; i++)
        {
            Inventory.Instance.AddItem(cropData.harvestedItem[0], 1);
        }

        isPlanted = false;
        cropData = null;
        spriteRenderer.sprite = null;
    }
}
