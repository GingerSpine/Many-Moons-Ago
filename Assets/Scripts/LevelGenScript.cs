using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenScript : MonoBehaviour {

    public GameObject platformPrefab;
    public float numberofPlatform;
    public float levelWidth;
    public float minY;
    public float maxY;
    public float aveRadius = 1f;
    public float irregularity = 0.8f;
    public float spikeyness = 0f;
    public int numVerts = 6;
    public int InRow = 2;
    public float numberOfTAPOK = 0;
    public GameObject[] TAPOKs;

    // Use this for initialization
    void Start () {

        //Vector3 spawnPosition = new Vector3();
        //AsteroidGenerator generator = new AsteroidGenerator(0f, 0f, aveRadius, irregularity, spikeyness, numVerts);
        /*
        for (int i = 0; i < numberofPlatform; i++)
        { 
            spawnPosition.y += Random.Range(minY, maxY);
            for (int j = 0; j < InRow; j++, i++)
            {
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                generator.generate(spawnPosition.x, spawnPosition.y);
            }
        }
        */
        Vector3 spawnPositionTAPOK = new Vector3();
        for (int i = 0; i <= numberOfTAPOK; i++)
        {
            spawnPositionTAPOK.y += Random.Range(minY, maxY);
            spawnPositionTAPOK.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(TAPOKs[Random.Range(0, TAPOKs.Length)], spawnPositionTAPOK, Quaternion.identity);

        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
