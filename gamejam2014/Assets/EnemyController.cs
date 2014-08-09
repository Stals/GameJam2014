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


        //transform.LookAt(playerShip.transform.position);


        // TODO look - get rotation, rotate back?))
        // mb this
        //http://gamedev.stackexchange.com/questions/18513/algo-for-rotating-tower-towards-enemy-unity

        /*Vector3 newForward = Vector3.Normalize(transform.position - playerShip.transform.position);
        // calc the rotation so the avatar faces the target
        Quaternion Rotation = GetRotation(Vector3.Forward, newForward, Vector3.Up);
        //Cannon.Shoot(Position, Rotation, this);

        transform.rotation = Rotation;*/

    }

    /*public static Quaternion GetRotation(Vector3 source, Vector3 dest, Vector3 up)
    {
        float dot = Vector3.Dot(source, dest);
        
        if (Math.Abs(dot - (-1.0f)) < 0.000001f)
        {
            // vector a and b point exactly in the opposite direction, 
            // so it is a 180 degrees turn around the up-axis
            return new Quaternion(up, MathHelper.ToRadians(180.0f));
        }
        if (Math.Abs(dot - (1.0f)) < 0.000001f)
        {
            // vector a and b point exactly in the same direction
            // so we return the identity quaternion
            return Quaternion.Identity;
        }
        
        float rotAngle = (float)Math.Acos(dot);
        Vector3 rotAxis = Vector3.Cross(source, dest);
        rotAxis = Vector3.Normalize(rotAxis);
        return Quaternion.CreateFromAxisAngle(rotAxis, rotAngle);
    }*/


    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag != this.gameObject.tag)
        {
            Game.Instance.getPlayer().addMoney(10);
            Destroy (gameObject);
            Destroy(coll.gameObject);
        }
    }
}
