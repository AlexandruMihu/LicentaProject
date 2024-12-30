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
  //  [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject interactionBox;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionBox.SetActive(false);
        }
    }

    public void PlantSeed(ItemSeed seed)
    {
        if (isPlanted) return; 

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

        //  spriteRenderer.sprite = cropData.growthStages[0];
        StartCoroutine(GrowCrop());
    }

    private IEnumerator GrowCrop()
    {
        while (growthTimer < cropData.growthTime)
        {
            growthTimer += Time.deltaTime;

            int stageIndex = Mathf.FloorToInt((growthTimer / cropData.growthTime) * cropData.growthStages.Length);
           // spriteRenderer.sprite = cropData.growthStages[Mathf.Clamp(stageIndex, 0, cropData.growthStages.Length - 1)];

            yield return null;
        }

       // spriteRenderer.sprite = cropData.growthStages[^1];
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
     //   spriteRenderer.sprite = null;
    }
}
