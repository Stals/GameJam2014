using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float flySpeed = 0.1f;

    public Gunner gunner;
    public float startShootingDelayMin = 0f;
    public float startShootingDelayMax = 0.5f;

    public float startShootingDelay;
    public float timeElapsed; // from creation

    private GameObject playerShip;

    private float prefferedDistanceToPlayer;

	// Use this for initialization
	void Start () {
        gunner = GetComponent<Gunner>();

        startShootingDelay = Random.Range(startShootingDelayMin, startShootingDelayMax);
        timeElapsed = 0;

        playerShip = Game.Instance.getPlayerShip();

        prefferedDistanceToPlayer = Random.Range(5, 7);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        bool moved = updatePosition();

        // TODO mb remove this
        // or check if moved into place
        if (!moved)
        {
            updateRotation();
            updateGun();
        }
    }

    void updateGun()
    {
        if (timeElapsed > startShootingDelay)
        {
            //if(getDistanceToPlayer() < 7){
                gunner.shoot();
            //}
            
        } else{ 
            timeElapsed += Time.deltaTime;
        }
    }

    void updateRotation()
    {
        Quaternion targetRotation = Quaternion.LookRotation
            (playerShip.transform.position - transform.position, transform.TransformDirection(Vector3.up));

        //float z = Mathf.Lerp(transform.rotation.z, targetRotation.z, Time.deltaTime * 5f);
        //float w = Mathf.Lerp(transform.rotation.w, targetRotation.w, Time.deltaTime * 5
        //transform.rotation = new Quaternion(0, 0,z , w);

        transform.rotation = new Quaternion(0, 0, targetRotation.z, targetRotation.w);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag != this.gameObject.tag)
        {
            Game.Instance.getPlayer().addMoney(10);
            Destroy (gameObject);

            if(coll.gameObject.layer != 8){ // player
                Destroy(coll.gameObject);
            }
        }
    }

    //return true if moved
    bool updatePosition()
    {
        float distance = getDistanceToPlayer();

        if (transform.position.x >= 0)
        {
            if (distance > prefferedDistanceToPlayer)
            {
                transform.position = new Vector3(transform.position.x - flySpeed, transform.position.y, 0);
                return true;
            } 
        }

        return false;
    }

    float getDistanceToPlayer(){
        //return Mathf.Abs(Mathf.Abs(playerShip.transform.position.x) - Mathf.Abs(transform.position.x));
        return Vector3.Distance (transform.position, playerShip.transform.position);
    }
}
