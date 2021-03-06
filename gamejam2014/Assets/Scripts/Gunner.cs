﻿using UnityEngine;
using System.Collections;

public class Gunner : MonoBehaviour {

    public Vector2 gunOffset = new Vector2(0f, 0f);
    public float bulletSpeed = 0.2f;

    public float shotDelay = 0.05f;
    public float shotTimeElapsed;

    public GameObject bulletPrefab;

    public int upgradeLevel = 0;
    public int maxUpgrades = 3;

	// Use this for initialization
	void Start () {
        shotTimeElapsed = shotDelay;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        updateShoot();
    }

    void updateShoot()
    {
        shotTimeElapsed += Time.deltaTime;
    }

    public void shoot()
    {
        if( shotTimeElapsed >= shotDelay){
            shotTimeElapsed = 0;

            if(upgradeLevel == 0){
                createBullet(new Vector2(0,0));
            }else if(upgradeLevel == 1){

                createBullet(new Vector2(0,0.25f));
                createBullet(new Vector2(0,-0.25f));

            }else{ //if(upgradeLevel == 2){
                createBullet(new Vector2(0,0.5f));
                createBullet(new Vector2(0,0));
                createBullet(new Vector2(0,-0.5f));
            }
        }
    }

    public GameObject createBullet(Vector2 bulletOffset){

        Vector2 currentPosition = transform.position;
        
        GameObject bulletObject = (GameObject)(Instantiate(bulletPrefab, new Vector3(currentPosition.x + gunOffset.x + bulletOffset.x, currentPosition.y + gunOffset.y + bulletOffset.y, 0), transform.rotation));
        bulletObject.tag = this.gameObject.tag;
        //bulletObject.layer = this.gameObject.layer;
        
        bulletObject.GetComponent<BulletController>().speed = new Vector3(bulletSpeed, 0);
        return bulletObject;
    }
}
