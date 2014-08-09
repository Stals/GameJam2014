using UnityEngine;
using System.Collections;

public class RepairObject : ShipObject {

    // Use this for initialization
    void Start () {

    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
    public override void performAction()
    {
        Game.Instance.getPlayer().addHP(1);
    }
}
