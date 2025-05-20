using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string COIN_KEY = "Coins";
    private readonly string INVENTORY_KEY_DATA = "MY_INVENTORY";
    private readonly string PLAYER_STATS_KEY = "PLAYER_STATS";
    private readonly string QUEST_KEY = "MY_QUESTS";
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        if (SaveGame.Exists(COIN_KEY))
            SaveGame.Save(COIN_KEY, 0);
        
        if (SaveGame.Exists(INVENTORY_KEY_DATA))
        {
            SaveGame.Delete(INVENTORY_KEY_DATA);
        }

        if (SaveGame.Exists(PLAYER_STATS_KEY))
        {
            SaveGame.Delete(PLAYER_STATS_KEY);
        }

        if (SaveGame.Exists(QUEST_KEY))
        { 
            SaveGame.Delete(QUEST_KEY);
        }

        PlayGame();
    }
}
