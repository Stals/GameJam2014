using UnityEngine;
using System.Collections;

public class PanelObject : ShipObject {

    public StateChanger stateChanger;
  
    /*void FixedUpdate()
    {
        if (Game.Instance.getCurrentState() != GameState.Walk){
            return;    
        }
        
        if (inside)
        {
            if(Input.GetKeyDown(KeyCode.Tab)){
                performAction();
            }
        }
    }*/

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
        stateChanger.changeToFly();
    }
}
