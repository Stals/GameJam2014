using UnityEngine;
using System.Collections;

public class RepairObject : ShipObject {

    public GameObject hint;
    
    // Use this for initialization
    void Start () {
        NGUITools.SetActive(hint, false);
    }
    
    // Update is called once per frame
    void Update () {
        NGUITools.SetActive(hint, inside);
    }
    
    public override void performAction()
    {
        Game.Instance.getPlayer().addHP(1);
    }
}
