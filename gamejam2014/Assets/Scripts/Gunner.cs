using UnityEngine;
using System.Collections;

public class Gunner : MonoBehaviour {

    public float shotDelay = 0.05f;
    public float shotTimeElapsed;

    public GameObject bulletPrefab;

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

            Vector2 currentPosition = transform.position;

            GameObject bulletObject = (GameObject)(Instantiate(bulletPrefab, new Vector3(currentPosition.x + 1f, currentPosition.y, 0), transform.rotation));
            bulletObject.tag = this.gameObject.tag;
            bulletObject.layer = this.gameObject.layer;

            //Game.Instance.getPlayer().removeHP(10);
        }
    }
}
