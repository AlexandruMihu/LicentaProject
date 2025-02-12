using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : Singletone<InventoryUI>
{
    [Header("Config")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container; 
    [SerializeField] private Transform bar;

    [Header("Description Panel")]
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    public InventorySlot CurrentSlot { get; set; }

    private List<InventorySlot> slotList = new List<InventorySlot>();
    private List<InventorySlot> barSlotList = new List<InventorySlot>(); 

    protected override void Awake()
    {
        base.Awake();
        InitInventory();
    }

    private void InitInventory()
    {
        for (int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefab, container);
            slot.Index = i;
            slotList.Add(slot);

            DisableButtonNavigation(slot);

            if (i < 10)
            {
                InventorySlot barSlot = Instantiate(slotPrefab, bar);
                barSlot.Index = i;
                barSlotList.Add(barSlot);

                DisableButtonNavigation(barSlot);
            }
        }
    }

    private void DisableButtonNavigation(InventorySlot slot)
    {
        Button button = slot.GetComponent<Button>();
        if (button != null)
        {
            Navigation noNav = new Navigation { mode = Navigation.Mode.None };
            button.navigation = noNav;
        }
    }

    public void DrawItem(InventoryItem item, int index)
    {
        if (index < 0 || index >= slotList.Count) return;

        InventorySlot slot = slotList[index];
        if (item == null)
        {
            slot.ShowSlotInformation(false);
        }
        else
        {
            slot.ShowSlotInformation(true);
            slot.UpdateSlot(item);
        }

        if (index < 10 && index < barSlotList.Count)
        {
            InventorySlot barSlot = barSlotList[index];
            if (item == null)
            {
                barSlot.ShowSlotInformation(false);
            }
            else
            {
                barSlot.ShowSlotInformation(true);
                barSlot.UpdateSlot(item);
            }
        }
    }

    public void ShowItemDescription(int index)
    {
        if (Inventory.Instance.InventoryItems[index] == null) return;
        descriptionPanel.SetActive(true);
        itemIcon.sprite = Inventory.Instance.InventoryItems[index].Icon;
        itemName.text = Inventory.Instance.InventoryItems[index].Name;
        itemDescription.text = Inventory.Instance.InventoryItems[index].Description;
    }

    public void OpenCloseInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        descriptionPanel.SetActive(false);
        if (!inventoryPanel.activeSelf)
        {
            CurrentSlot = null;
        }
    }

    public void UseItem()
    {
        if (CurrentSlot == null) return;
        Inventory.Instance.UseItem(CurrentSlot.Index);
    }

    public void RemoveItem()
    {
        if (CurrentSlot == null) return;
        Inventory.Instance.RemoveItem(CurrentSlot.Index);
    }

    public void EquipItem()
    {
        if (CurrentSlot == null) return;
        Inventory.Instance.EquipItem(CurrentSlot.Index);
    }

    private void SlotSelectedCallback(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slotList.Count) return;

        if (CurrentSlot != null)
        {
            Button previousButton = CurrentSlot.GetComponent<Button>();
            if (previousButton != null)
            {
                previousButton.OnDeselect(null); 
            }

            if (CurrentSlot.Index < barSlotList.Count)
            {
                Button previousBarButton = barSlotList[CurrentSlot.Index].GetComponent<Button>();
                if (previousBarButton != null)
                {
                    previousBarButton.OnDeselect(null);
                }
            }
        }

        CurrentSlot = slotList[slotIndex];
        ShowItemDescription(slotIndex);

        Button newButton = CurrentSlot.GetComponent<Button>();
        if (newButton != null)
        {
            newButton.OnSelect(null);
        }

        if (slotIndex < barSlotList.Count)
        {
            Button barButton = barSlotList[slotIndex].GetComponent<Button>();
            if (barButton != null)
            {
                barButton.OnSelect(null);
            }
        }
    }



    private void OnEnable()
    {
        InventorySlot.OnSlotSelectedEvent += SlotSelectedCallback;
    }

    private void OnDisable()
    {
        InventorySlot.OnSlotSelectedEvent -= SlotSelectedCallback;
    }
}
