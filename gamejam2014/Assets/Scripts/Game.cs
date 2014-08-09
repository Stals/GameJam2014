using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game  {
    private static Game instance;
    private Game() {}
    public static Game Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }
    }
    
    Player player;
    GameObject playerShip;

    
    public void init(GameObject _playerShip)
    {
        player = new Player(100);
        playerShip = _playerShip;
    }

    public Player getPlayer(){
        return player;
    }

    public GameObject getPlayerShip()
    {
        return playerShip;
    }
}