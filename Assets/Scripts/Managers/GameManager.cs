using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : Singletone<GameManager>
{

    [SerializeField] private Player player;

    public Player Player => player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.ResetPlayer();
        }
    }

    public void AddPlayerExp(float expAmount)
    {
        PlayerExp playerExp = player.GetComponent<PlayerExp>();
        playerExp.AddExperience(expAmount);
    }

}