using UnityEngine;
using System.Collections;

public class UpgradeObject : ShipObject {
    public GameObject hint;
    
    // Use this for initialization
    void Start () {
        NGUITools.SetActive(hint, false);
        once = true;
    }
    
    // Update is called once per frame
    void Update () {
        NGUITools.SetActive(hint, inside);
    }
    
    public override void performAction()
    {
        Gunner gunner = Game.Instance.getPlayerShip().GetComponent<Gunner>();
        gunner.upgradeLevel += 1;
    }
}
