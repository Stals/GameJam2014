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

    public CameraShake cameraShake;

    private float targetCamSize;
    private Vector3 targetCamPosition;

    private float transitionTimeScale = 9f;

	// Use this for initialization
	void Start () {
        targetCamSize = mainCam.orthographicSize;
        targetCamPosition = mainCam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Mathf.Lerp(hpSlider.value, targetValue, Time.deltaTime * 5f);

        //targetCamSize

        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, targetCamSize, Time.deltaTime * transitionTimeScale);
	
        float x = Mathf.Lerp(mainCam.transform.position.x, targetCamPosition.x, Time.deltaTime * transitionTimeScale);
        float y = Mathf.Lerp(mainCam.transform.position.y, targetCamPosition.y, Time.deltaTime * transitionTimeScale);
    
        mainCam.transform.position = new Vector3(x, y, -10);

        /*if ((mainCam.transform.position.x != targetCamPosition.x) || 
            (mainCam.transform.position.x != targetCamPosition.x))
        {
            cameraShake.stopShake();
        }*/
    }

    void FixedUpdate(){
        updateLabel();

        if (Input.GetKeyDown(changeButton))
        {
            if(Game.Instance.getCurrentState() == GameState.Fly){
                changeToWalk();
            }

            else if(Game.Instance.getCurrentState() == GameState.Walk){
                changeToFly();
            }
        }
    }

    public void changeToWalk()
    {
        cameraShake.stopShake();

        Game.Instance.setCurrentState( GameState.Walk );
        
        targetCamSize = closeSize;
        
        Vector3 playerPosition = Game.Instance.getPlayerShip().transform.position;
        targetCamPosition = new Vector3(playerPosition.x, playerPosition.y, -10);
        
        shipOverlay.SetActive(false);
        engineBar.gameObject.SetActive(true);

        // reset walking player position
        walkingPlayer.transform.localPosition = new Vector3(-5.5f, 0f, 0f);
    }

    public void changeToFly()
    {
        cameraShake.stopShake();

        Game.Instance.setCurrentState( GameState.Fly );
        
        mainCam.orthographicSize = farSize;
        mainCam.transform.position = new Vector3(0, 0, -10);
        shipOverlay.SetActive(true);
        engineBar.gameObject.SetActive(false);

        targetCamSize = mainCam.orthographicSize;
        targetCamPosition = mainCam.transform.position;
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
