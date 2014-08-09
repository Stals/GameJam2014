using UnityEngine;
using System.Collections;



public class GuiManager : MonoBehaviour {

    public UISlider hpSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        float targetValue = Game.Instance.getPlayer().getHpFactor();
        hpSlider.value = Mathf.Lerp(hpSlider.value, targetValue, Time.deltaTime * 5f);
    }
}
