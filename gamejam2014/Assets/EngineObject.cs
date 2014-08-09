using UnityEngine;
using System.Collections;

public class EngineObject : MonoBehaviour {

    public GameObject hint;

	// Use this for initialization
	void Start () {
        hint.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.layer == 12) // WalkingPlayer
        {
            hint.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.layer == 12) // WalkingPlayer
        {
            hint.SetActive(false);
        }
    }
}
