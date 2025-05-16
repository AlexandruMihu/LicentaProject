using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MainMenu : MonoBehaviour
{
    private const string COIN_KEY = "Coins";
    private readonly string INVENTORY_KEY_DATA = "MY_INVENTORY";
    private readonly string PLAYER_STATS_KEY = "PLAYER_STATS";
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
        SaveGame.Save(COIN_KEY, 0);
        
        if (SaveGame.Exists(INVENTORY_KEY_DATA))
        {
            SaveGame.Delete(INVENTORY_KEY_DATA);
        }

        if (SaveGame.Exists(PLAYER_STATS_KEY))
        {
            SaveGame.Delete(PLAYER_STATS_KEY);
        }
        PlayGame();
    }
}
