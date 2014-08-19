using UnityEngine;
using System.Collections;

public class UpgradeObject : ShipObject {
    public GameObject hint;
    
    // Use this for initialization
    void Start () {
        NGUITools.SetActive(hint, false);
        once = true;
    }
    
    // Update is called once per frame
    void Update () {
        NGUITools.SetActive(hint, inside);
    }
    
    public override void performAction()
    {
        Gunner gunner = Game.Instance.getPlayerShip().GetComponent<Gunner>();
        gunner.upgradeLevel += 1;
        gunner.shotDelay = 0.3f / gunner.upgradeLevel;
        if (gunner.upgradeLevel == 1)
        {
            gunner.shotDelay = 0.3f;
        }
        else if (gunner.upgradeLevel == 2)
        {
            gunner.shotDelay = 0.25f;
        }
        else if (gunner.upgradeLevel == 3)
        {
            gunner.shotDelay = 0.2f;
        }

        if (gunner.upgradeLevel > (gunner.maxUpgrades - 1))
        {
            gunner.upgradeLevel = gunner.maxUpgrades - 1;
        } else
        {
            Game.Instance.getPlayer().removeMoney(gunner.upgradeLevel * 50);
            GetComponent<AudioSource>().Play();
        }
    }
}
