using UnityEngine;
using System.Collections;

public class StateChanger : MonoBehaviour {

    public KeyCode changeButton;
    public Camera mainCam;

    public float closeSize;
    public float farSize;

    public GameObject shipOverlay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate(){
        if (Input.GetKeyDown(changeButton))
        {
            if(Game.Instance.getCurrentState() == GameState.Fly){
                Game.Instance.setCurrentState( GameState.Walk );

                mainCam.orthographicSize = closeSize;

                Vector3 playerPosition = Game.Instance.getPlayerShip().transform.position;
                mainCam.transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);

                shipOverlay.SetActive(false);
            }

            else if(Game.Instance.getCurrentState() == GameState.Walk){
                Game.Instance.setCurrentState( GameState.Fly );
                
                mainCam.orthographicSize = farSize;
                mainCam.transform.position = new Vector3(0, 0, -10);
                shipOverlay.SetActive(true);
            }
        }
    }
}
