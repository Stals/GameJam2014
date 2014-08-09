using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum GameState{
    Fly,
    Walk,
    GameOver,
    GameStart
};

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
    GameState state;

    
    public void init(GameObject _playerShip)
    {
        player = new Player(100);
        playerShip = _playerShip;

        state = GameState.Fly;
    }

    public Player getPlayer(){
        return player;
    }

    public GameObject getPlayerShip()
    {
        return playerShip;
    }

    public GameState getCurrentState()
    {
        return state;
    }

    public void setCurrentState(GameState _state)
    {
        state = _state;
    }
}