using UnityEngine;
using System.Collections;

public class WalkingPlayerController : MonoBehaviour {

    public Vector2 speed = new Vector2(0.02f, 0.02f);

    Vector3 currentPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        currentPosition = this.transform.position;
        if (Game.Instance.getCurrentState() == GameState.Walk)
        {
            updateMovment();

        }
    }

    void updateMovment()
    {
        PlayerContoller playerController = Game.Instance.getPlayerShip().GetComponent<PlayerContoller>();

        Vector2 v = new Vector2(0f, 0f);
        
        if (Input.GetKey (playerController.moveUp)) 
        {
            v.y += speed.y;
        }
        if (Input.GetKey (playerController.moveDown)) 
        {
            v.y -= speed.y;
        }
        if (Input.GetKey(playerController.moveLeft))
        {
            v.x -= speed.x;
        }
        if (Input.GetKey(playerController.moveRight))
        {
            v.x += speed.x;
        }
        
        this.transform.position  =  new Vector3(currentPosition.x + v.x, currentPosition.y + v.y);
    }
}
