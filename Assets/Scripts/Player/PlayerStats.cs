using BayatGames.SaveGameFree;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    Strenght,
    Dexterity,
    Intelligence
}

[Serializable]
public class PlayerStatsData
{
    public int Level;
    public float Health, MaxHealth;
    public float Mana, MaxMana;
    public float CurrentExp, NextLevelExp, InitialNextLevelExp, ExpMultiplier;
    public float BaseDamage, CriticalChance, CriticalDamage;
    public int Strength, Dexterity, Intelligence, AttributePoints;
}

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Config")]
    public int Level;

    [Header("Heath")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")]
    public float Mana;
    public float MaxMana;

    [Header("Exp")]
    public float CurrentExp;
    public float NextLevelExp;
    public float InitialNextLevelExp;
    [Range(1, 100)] public float ExpMultiplier;

    [Header("Attack")]
    public float BaseDamage;
    public float CriticalChance;
    public float CriticalDamage;

    [Header("Attributes")]
    public int Strenght;
    public int Dexterity;
    public int Intelligence;
    public int AttributePoints;

    [HideInInspector] public float TotalExp;
    [HideInInspector] public float TotalDamage;

    private const string SAVE_KEY = "PLAYER_STATS";

    public void LoadStats()
    {
        if (SaveGame.Exists(SAVE_KEY))
        {
            var data = SaveGame.Load<PlayerStatsData>(SAVE_KEY);

            Level = data.Level;
            Health = data.Health;
            MaxHealth = data.MaxHealth;
            Mana = data.Mana;
            MaxMana = data.MaxMana;
            CurrentExp = data.CurrentExp;
            NextLevelExp = data.NextLevelExp;
            InitialNextLevelExp = data.InitialNextLevelExp;
            ExpMultiplier = data.ExpMultiplier;
            BaseDamage = data.BaseDamage;
            CriticalChance = data.CriticalChance;
            CriticalDamage = data.CriticalDamage;
            Strenght = data.Strength;
            Dexterity = data.Dexterity;
            Intelligence = data.Intelligence;
            AttributePoints = data.AttributePoints;
        }
        else
        {
            ResetPlayer();
            SaveStats();
        }
    }

    public void SaveStats()
    {
        var data = new PlayerStatsData
        {
            Level = Level,
            Health = Health,
            MaxHealth = MaxHealth,
            Mana = Mana,
            MaxMana = MaxMana,
            CurrentExp = CurrentExp,
            NextLevelExp = NextLevelExp,
            InitialNextLevelExp = InitialNextLevelExp,
            ExpMultiplier = ExpMultiplier,
            BaseDamage = BaseDamage,
            CriticalChance = CriticalChance,
            CriticalDamage = CriticalDamage,
            Strength = Strenght,
            Dexterity = Dexterity,
            Intelligence = Intelligence,
            AttributePoints = AttributePoints
        };
        SaveGame.Save(SAVE_KEY, data);
    }

    public void ResetPlayer()
    {
        Level = 1; 
        MaxHealth = 20;
        Health = MaxHealth;
        MaxMana = 20;
        Mana = MaxMana;
        CurrentExp = 0;
        NextLevelExp = InitialNextLevelExp;
        TotalExp = 0;
        BaseDamage = 2;
        CriticalChance = 10;
        CriticalDamage = 50;
        Strenght = 0;
        Dexterity = 0;
        Intelligence = 0;
        AttributePoints = 0;
    }
}
