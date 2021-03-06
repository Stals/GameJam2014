﻿using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    public GameObject playerShip;

    public Camera mainCam;
    
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    public KeyCode resetPlayerPosition;

	// Use this for initialization
	void Start () {
        Game.Instance.init(playerShip);

        setupWalls();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(resetPlayerPosition))
        {
            playerShip.transform.position = new Vector3(-5, 0, 0);
        }
	}

    void setupWalls()
    {
        //Move each wall to its edge location:
        topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.center = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y + 0.5f);
        
        bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2, 0f, 0f)).x, 1f);
        bottomWall.center = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y - 0.5f);
        
        leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);;
        leftWall.center = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);
        
        rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
        rightWall.center = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
    }
}
