using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public static event Action<int> OnSlotSelectedEvent;

    [Header("Config")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image quantityContainer;
    [SerializeField] private TextMeshProUGUI itemQuantityTMP;
    public int Index { get; set; }
    private void Update()
    {
        DetectNumberKeyPress();
    }

    private void DetectNumberKeyPress()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i)) 
            {
                SelectSlotByKey(i - 1); 
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SelectSlotByKey(9); 
        }
    }

    private void SelectSlotByKey(int key)
    {
        OnSlotSelectedEvent?.Invoke(key); 
    }

    public void ClickSlot()
    {
        OnSlotSelectedEvent?.Invoke(Index);
    }

    public void UpdateSlot(InventoryItem item)
    {
        itemIcon.sprite = item.Icon;
        itemQuantityTMP.text = item.Quantity.ToString();
        itemIcon.SetNativeSize();
    }

    public void ShowSlotInformation(bool value)
    {
        itemIcon.gameObject.SetActive(value);
        quantityContainer.gameObject.SetActive(value);
    }
}

