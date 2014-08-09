using UnityEngine;
using System.Collections;

// TODO self destruct if off screen
public class BulletController : MonoBehaviour {

    public Vector2 speed = new Vector2(0.2f, 0);
   

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

    void updateMovment()
    {
        Vector3 currentPosition = this.transform.position;
        this.transform.position  =  new Vector3(currentPosition.x + speed.x, currentPosition.y + speed.y);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag != this.gameObject.tag)
        {
            Destroy (gameObject);
            Destroy(coll.gameObject);
        }
    }
}
