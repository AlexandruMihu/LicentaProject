using System;
using System.Linq;
using UnityEngine;

public class FarmingManager : Singletone<FarmingManager>
{
    private PlayerActions actions;
    private int selectedCropIndex = -1;
    public CropSpot CropSpotSelected
    {
        get => cropSpotSelected;
        set
        {
            cropSpotSelected = value;
            selectedCropIndex = Array.IndexOf(cropSpots, cropSpotSelected); 
        }
    }
    private CropSpot cropSpotSelected;

    [Header("References")]
    [SerializeField] public CropSpot[] cropSpots;
    [SerializeField] private ItemSeed testSeed;

    protected override void Awake()
    {
        base.Awake();
        actions = new PlayerActions();
    }

    private void Start()
    {
        actions.Farming.Plant.performed += ctx => PlantSeedAtSpot(selectedCropIndex, testSeed);
        actions.Farming.Harvest.performed += ctx => HarvestAtSpot(selectedCropIndex);
    }

    private void OnDestroy()
    {
        actions.Farming.Plant.performed -= ctx => PlantSeedAtSpot(selectedCropIndex, testSeed);
        actions.Farming.Harvest.performed -= ctx => HarvestAtSpot(selectedCropIndex);
    }

    public void PlantSeedAtSpot(int spotIndex, ItemSeed seed)
    {
        if (spotIndex < 0 || spotIndex >= cropSpots.Length) return;

        cropSpots[spotIndex].PlantSeed(seed);
    }

    public void HarvestAtSpot(int spotIndex)
    {
        if (spotIndex < 0 || spotIndex >= cropSpots.Length) return;

        cropSpots[spotIndex].HarvestCrop();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
