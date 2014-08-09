using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

    public Vector2 speed = new Vector2(0.1f, 0.1f);


    public KeyCode moveUp;
    public KeyCode moveDown;

    public KeyCode moveLeft;
    public KeyCode moveRight;

    public KeyCode shootButton;

    public Gunner gunner;

    Vector3 currentPosition;

	// Use this for initialization
	void Start () {
        currentPosition = this.transform.position;
        gunner = GetComponent<Gunner>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{123
        currentPosition = this.transform.position;
        if (Game.Instance.getCurrentState() == GameState.Fly)
        {
            updateMovment();
            updateShoot();
        }
	}

    void updateShoot()
    {
        if (Input.GetKey(shootButton))
        {
            gunner.shoot();

        } 
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

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Wall"){
            return;
        }

        if (coll.gameObject.layer == 12) // WalkingPlayer
        {
            return;
        }

        if (coll.gameObject.tag != this.gameObject.tag)
        {
            Game.Instance.getPlayer().removeHP(5);
            Destroy(coll.gameObject);
        }
    }

}
