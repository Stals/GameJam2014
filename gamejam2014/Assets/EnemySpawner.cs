using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> patternPrefabs;
    public List<float> delays;

    public float waveDelay = 10;

    public float timeElapsed;

    public int currentID;

    float screenWidthInPoints;
    float height;

	// Use this for initialization
	void Start () {
        timeElapsed = 0;
        currentID = 0;

        height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
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

        Vector3 spawnPosition = getPatternStartPosition(prefab);

        Instantiate(prefab, new Vector3(spawnPosition.x, spawnPosition.y, 0), prefab.transform.rotation);
    }

    Vector3 getPatternStartPosition(GameObject pattern)
    {
        //Debug.Log("World Height " + height.ToString());
        //Debug.Log("pattern height " + getHeight(pattern));

        float freeSpaceY = height - getBounds(pattern).y - 0.5f;

        return new Vector3(12, Random.Range(-freeSpaceY/2, freeSpaceY/2), 0);
    }

    Vector3 getBounds(GameObject go)
    {
        // First find a center for your bounds.
        Vector3 center = Vector3.zero;

        foreach (Transform t in go.transform)
        {
            foreach (Transform child in t)
            {
                Renderer renderer = child.gameObject.renderer;
                center += child.gameObject.renderer.bounds.center;   
            }
        }
        center /= go.transform.childCount; //center is average center of children
        
        //Now you have a center, calculate the bounds by creating a zero sized 'Bounds', 
        Bounds bounds = new Bounds(center,Vector3.zero); 

        foreach (Transform t in go.transform)
        {
            foreach (Transform child in t)
            {
                bounds.Encapsulate(child.gameObject.renderer.bounds);   
            }
        }
        
        return bounds.size;
    }
}
