﻿using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

    public Vector2 speed = new Vector2(0.1f, 0.1f);
    public float shotDelay = 0.05f;
    public float shotTimeElapsed;

    public KeyCode moveUp;
    public KeyCode moveDown;

    public KeyCode moveLeft;
    public KeyCode moveRight;

    public KeyCode shootButton;


    public GameObject playerBulletPrefab;
    Vector3 currentPosition;

	// Use this for initialization
	void Start () {
        currentPosition = this.transform.position;
        shotTimeElapsed = shotDelay;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
        currentPosition = this.transform.position;

        updateMovment();
        updateShoot();
	}

    void updateMovment(){
        Vector2 v = new Vector2(0f, 0f);
        
        if (Input.GetKey (moveUp)) 
        {
            v.y += speed.y;
        }
        if (Input.GetKey (moveDown)) 
        {
            v.y -= speed.y;
        }
        if (Input.GetKey(moveLeft))
        {
            v.x -= speed.x;
        }
        if (Input.GetKey(moveRight))
        {
            v.x += speed.x;
        }


        this.transform.position  =  new Vector3(currentPosition.x + v.x, currentPosition.y + v.y);
    }

    void updateShoot()
    {
        shotTimeElapsed += Time.deltaTime;

        if (Input.GetKey(shootButton))
        {
            if( shotTimeElapsed >= shotDelay){
                shotTimeElapsed = 0;
                shoot();
            }
        } 
    }

    void shoot()
    {


        Instantiate(playerBulletPrefab, new Vector3(currentPosition.x + 1f, currentPosition.y, 0), transform.rotation);
    }
}