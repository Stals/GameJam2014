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

    
    public void init()
    {
        player = new Player(100);
    }
    
    public Player getPlayer(){
        return player;
    }
}