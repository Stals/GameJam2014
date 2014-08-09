using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> patternPrefabs;
    public float waveDelay = 10;

    public float timeElapsed;

	// Use this for initialization
	void Start () {
        timeElapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= waveDelay)
        {
            timeElapsed = 0;
            spawnWave();
        }
    }

    void spawnWave()
    {
        int patternID = 0;//Random.Range(0, patternPrefabs.Count - 1);
        GameObject prefab = patternPrefabs[patternID];

        Vector3 spawnPosition = getPatternStartPosition();

        Instantiate(prefab, new Vector3(spawnPosition.x, spawnPosition.y, 0), prefab.transform.rotation);
    }

    Vector3 getPatternStartPosition()
    {
        return new Vector3(9, Random.Range(-3, 3), 0);
    }
}
