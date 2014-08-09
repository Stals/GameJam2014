using UnityEngine;
using System.Collections;

public class StateChanger : MonoBehaviour {

    public KeyCode changeButton;
    public Camera mainCam;

    public float closeSize;
    public float farSize;

    public GameObject shipOverlay;

    public UILabel switchLabel;
    public UISlider engineBar;

    public GameObject walkingPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate(){
        updateLabel();

        if (Input.GetKeyDown(changeButton))
        {
            if(Game.Instance.getCurrentState() == GameState.Fly){
                changeToWalk();
            }

            //else if(Game.Instance.getCurrentState() == GameState.Walk){
            //    changeToFly();
            //}
        }
    }

    public void changeToWalk()
    {
        Game.Instance.setCurrentState( GameState.Walk );
        
        mainCam.orthographicSize = closeSize;
        
        Vector3 playerPosition = Game.Instance.getPlayerShip().transform.position;
        mainCam.transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
        
        shipOverlay.SetActive(false);
        engineBar.gameObject.SetActive(true);

        walkingPlayer.transform.localPosition = new Vector3(-5.5f, 0f, 0f);
    }

    public void changeToFly()
    {
        Game.Instance.setCurrentState( GameState.Fly );
        
        mainCam.orthographicSize = farSize;
        mainCam.transform.position = new Vector3(0, 0, -10);
        shipOverlay.SetActive(true);
        engineBar.gameObject.SetActive(false);
    }

    void updateLabel()
    {
        if (Game.Instance.getCurrentState() == GameState.Walk)
        {
            switchLabel.text = "Acess Desk\nTo Pilot";
        } 
        else if (Game.Instance.getCurrentState() == GameState.Fly)
        {
            switchLabel.text = "Press TAB\nTo Walk on Ship";
        }
    }

}
