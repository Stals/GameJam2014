using UnityEngine;
using System.Collections;

public class AnimationDestroyer : MonoBehaviour {

    public float timeBeforeDestroy = 3f;

	// Use this for initialization
	void Start () {
        StartCoroutine(destr()); //this will run your timer

	}

    
    IEnumerator destr() {
        yield return new WaitForSeconds(timeBeforeDestroy); //this will wait 5 seconds
        Destroy(gameObject);
    }
}
