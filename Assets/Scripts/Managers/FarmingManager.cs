using System;
using UnityEngine;

public class FarmingManager : Singletone<FarmingManager>
{
    private PlayerActions actions;
    public CropSpot CropSpotSelected { get; set; }

    [Header("References")]
    [SerializeField] private CropSpot[] cropSpots;
    [SerializeField] private ItemSeed testSeed;

    protected override void Awake()
    {
        base.Awake();
        actions = new PlayerActions();
    }

    private void Start()
    {
        actions.Farming.Plant.performed += ctx => Handle();
    }
    private void OnDestroy()
    {
        actions.Farming.Plant.performed -= ctx => Handle();
    }

    private void Handle()
    {
        if(testSeed != null)
        {

            PlantSeedAtSpot(0, testSeed);
        }
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
