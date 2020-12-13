using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawnBehaviour : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject linePrefab;
    public float timeBetweenSpawns;
    private float _timeBetweemSpawnsTimer;
    
    

    
    void Update()
    {
        if (_timeBetweemSpawnsTimer <= 0)
        {
            var SpawnPointNumber = Random.Range(1, spawnPoints.Length);
            Instantiate(linePrefab, spawnPoints[SpawnPointNumber].position , Quaternion.identity);
            _timeBetweemSpawnsTimer = timeBetweenSpawns;

        }
        else
        {
            _timeBetweemSpawnsTimer -= Time.deltaTime;
        }
    }
}
