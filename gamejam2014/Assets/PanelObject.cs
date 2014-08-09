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

    public override void performAction()
    {
        stateChanger.changeToFly();
    }
}
