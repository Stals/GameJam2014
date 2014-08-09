using UnityEngine;
using System.Collections;

public class PanelObject : ShipObject {

    public StateChanger stateChanger;
  
    public override void performAction()
    {
        stateChanger.changeToFly();
    }
}
