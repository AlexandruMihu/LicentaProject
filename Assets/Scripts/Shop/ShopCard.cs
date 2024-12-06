using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ShopCard:MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCost;
    [SerializeField] private TextMeshProUGUI buyAmount;


    private ShopItem item;
    private int quantity;
    private float initialCost;
    private float currentCost;

    private void Update()
    {
        buyAmount.text = quantity.ToString();
        itemCost.text = currentCost.ToString();
    }

    public void ConfigShopCard(ShopItem shopItem)
    {
        item = shopItem;
        itemIcon.sprite = shopItem.Item.Icon;
        itemName.text = shopItem.Item.Name;
        itemCost.text = shopItem.Cost.ToString();
        quantity = 1;
        initialCost = shopItem.Cost;
        currentCost = shopItem.Cost;
    }

    public void BuyItem()
    {
        if(CoinManager.Instance.Coins >= currentCost)
        {
            Inventory.Instance.AddItem(item.Item, quantity);
            CoinManager.Instance.RemoveCoins(currentCost);
            quantity = 1;
            currentCost = initialCost;
        }
    }

    public void Add()
    {
        Console.WriteLine("yes");
        float buyCost = initialCost * (quantity + 1);
        if(CoinManager.Instance.Coins >= buyCost )
        {
            quantity++;
            currentCost = initialCost*quantity;
        }
    }

    public void Remove()
    {
        if(quantity==1) return;
        quantity--;
        currentCost = initialCost*quantity;
    }
}
