using UnityEngine;

public class FarmingManager : Singletone<FarmingManager>
{
    [Header("References")]
    [SerializeField] private CropSpot[] cropSpots;

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
}
