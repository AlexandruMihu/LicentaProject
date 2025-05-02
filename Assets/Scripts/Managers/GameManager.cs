using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singletone<GameManager>
{

    [SerializeField] private Player player;

    public Player Player => player;
    private PlayerActions actions;

    protected override void Awake()
    {
        base.Awake();
        actions = new PlayerActions();
    }

    private void Start()
    {
        actions.General.MainMenu.performed += ctx => QuitGame();
        actions.General.ResetPlayer.performed += ctx => player.ResetPlayer();
        actions.General.AddExperience.performed += ctx => AddPlayerExp(380);

    }

    private void OnDestroy()
    {
        actions.General.MainMenu.performed -= ctx => QuitGame();
        actions.General.ResetPlayer.performed -= ctx => player.ResetPlayer();
        actions.General.AddExperience.performed -= ctx => AddPlayerExp(380);
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync("Main Menu Scene");
    }

    public void AddPlayerExp(float expAmount)
    {
        PlayerExp playerExp = player.GetComponent<PlayerExp>();
        playerExp.AddExperience(expAmount);
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