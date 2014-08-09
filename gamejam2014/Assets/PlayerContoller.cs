using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

    private Vector2 speed = new Vector2(0.1f, 0.1f);

    public KeyCode moveUp;
    public KeyCode moveDown;

    public KeyCode moveLeft;
    public KeyCode moveRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
        updateMovment();
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

        Vector3 currentPosition = this.transform.position;
        this.transform.position  =  new Vector3(currentPosition.x + v.x, currentPosition.y + v.y);
    }
}
