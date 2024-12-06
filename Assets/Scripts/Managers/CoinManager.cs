using BayatGames.SaveGameFree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CoinManager:Singletone<CoinManager>
{
    [SerializeField] private float CoinTest;
    public float Coins { get; private set; }
    private const string COIN_KEY = "Coins";

    private void Start()
    {
        if (SaveGame.Exists(COIN_KEY))
        {
            Coins = SaveGame.Load(COIN_KEY, CoinTest);
        }
        else
        {
            Coins = CoinTest;
            SaveGame.Save(COIN_KEY, Coins);
        }
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
        SaveGame.Save(COIN_KEY, Coins);
    }

    public void RemoveCoins(float amount) 
    {
        if(Coins >= amount)
        {
            Coins -= amount;
            SaveGame.Save(COIN_KEY,Coins);
        }
    } 
}

