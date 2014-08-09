using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public Gunner gunner;

	// Use this for initialization
	void Start () {
        gunner = GetComponent<Gunner>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        gunner.shoot();
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
