using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    public GameObject playerShip;

	// Use this for initialization
	void Start () {
        Game.Instance.init(playerShip);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
