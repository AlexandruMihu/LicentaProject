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
            plantInteractionBox.SetActive(true);
        }
        else if (canHarvest)
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

        cropSpriteRenderer.sprite = cropData.growthStages[0]; // Set the initial crop sprite
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

        for (int i = 0; i < cropData.harvestCount; i++)
        {
            Inventory.Instance.AddItem(cropData.harvestedItem[0], 1);
        }

        canHarvest = false;
        isPlanted = false;
        cropData = null;
        cropSpriteRenderer.sprite = null; // Clear the crop sprite
        harvestInteractionBox.SetActive(false);
    }
}
