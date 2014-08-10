﻿using UnityEngine;
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
