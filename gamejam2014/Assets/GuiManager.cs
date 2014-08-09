using UnityEngine;
using System.Collections;


// TODO add money with lerp
public class GuiManager : MonoBehaviour {

    public UISlider hpSlider;
    public UILabel moneyLabel;

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

        moneyLabel.text = Game.Instance.getPlayer().getMoney().ToString();
    }
}
