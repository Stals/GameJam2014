using UnityEngine;
using System.Collections;

public class ShipObject : MonoBehaviour {

    public KeyCode actionButton;
    
    
    bool inside;
    
    // Use this for initialization
    void Start () {
        inside = true;
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
    void FixedUpdate()
    {
        if (inside)
        {
            if(Input.GetKey(actionButton)){
                performAction();
            }
        }
    }

    public virtual void performAction()
    {

    }
    
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.layer == 12) // WalkingPlayer
        {
            inside = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.layer == 12) // WalkingPlayer
        {
            inside = false;
        }
    }
}
