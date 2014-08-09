using UnityEngine;
using System.Collections;

public class EngineObject : ShipObject {

    public GameObject hint;

	// Use this for initialization
	void Start () {
        hint.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        hint.SetActive(inside);
	}
    public override void performAction()
    {
        Game.Instance.getPlayer().addEngine(Game.Instance.getPlayer().getEnginePerTick());
    }
}
