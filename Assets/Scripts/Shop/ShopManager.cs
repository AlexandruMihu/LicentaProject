﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ShopManager:Singletone<ShopManager>
{
    [Header("Config")]
    [SerializeField] private ShopCard shopCardPrefab;
    [SerializeField] private Transform shopContainer;

    [Header("Items")]
    [SerializeField] private ShopItem[] items;

    private void Start()
    {
        LoadShop();
    }

    private void LoadShop()
    {
        for(int i = 0;i < items.Length; i++)
        {
            ShopCard card = Instantiate(shopCardPrefab, shopContainer);
            card.ConfigShopCard(items[i]);
        }
    }
}

