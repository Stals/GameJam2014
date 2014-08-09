using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public Gunner gunner;
    public float startShootingDelayMin = 0f;
    public float startShootingDelayMax = 0.5f;

    public float startShootingDelay;
    public float timeElapsed; // from creation

    private GameObject playerShip;

	// Use this for initialization
	void Start () {
        gunner = GetComponent<Gunner>();

        startShootingDelay = Random.Range(startShootingDelayMin, startShootingDelayMax);
        timeElapsed = 0;

        playerShip = Game.Instance.getPlayerShip();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        updateRotation();
        updateGun();
    }

    void updateGun()
    {
        if (timeElapsed > startShootingDelay)
        {
            gunner.shoot();
            
        } else{ 
            timeElapsed += Time.deltaTime;
        }
    }

    void updateRotation()
    {
        Quaternion rotation = Quaternion.LookRotation
            (playerShip.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag != this.gameObject.tag)
        {
            Game.Instance.getPlayer().addMoney(10);
            Destroy (gameObject);
            Destroy(coll.gameObject);
        }
    }
}
