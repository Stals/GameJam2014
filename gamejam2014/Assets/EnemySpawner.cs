using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> patternPrefabs;
    public List<float> delays;

    public float waveDelay = 10;

    public float timeElapsed;

    public int currentID;

	// Use this for initialization
	void Start () {
        timeElapsed = 0;
        currentID = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float getTimeBeforeWave()
    {
        return getCurrentDelay() - timeElapsed;
    }

    float getCurrentDelay()
    {
        if (currentID < delays.Count)
        {
            return delays[currentID];
        }

        return delays[delays.Count - 1];
    }

    GameObject getCurrentWave()
    {
        if (currentID < patternPrefabs.Count)
        {
            return patternPrefabs [currentID];
        } 
        return patternPrefabs[patternPrefabs.Count - 1];
    }

    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= getCurrentDelay())
        {
            timeElapsed = 0;
            spawnWave(getCurrentWave());
            ++currentID;
        }
    }

    void spawnWave(GameObject prefab)
    {
        //int patternID = Random.Range(0, patternPrefabs.Count);
        //GameObject prefab = patternPrefabs[patternID];

        Vector3 spawnPosition = getPatternStartPosition();

        Instantiate(prefab, new Vector3(spawnPosition.x, spawnPosition.y, 0), prefab.transform.rotation);
    }

    Vector3 getPatternStartPosition()
    {
        return new Vector3(12, Random.Range(-3, 3), 0);
    }
}
