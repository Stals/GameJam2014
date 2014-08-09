using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int i = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag != this.gameObject.tag)
        {
            Destroy (gameObject);
            Destroy(coll.gameObject);
        }
    }
}
