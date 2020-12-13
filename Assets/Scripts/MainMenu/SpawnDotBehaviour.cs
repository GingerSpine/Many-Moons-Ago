using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDotBehaviour : MonoBehaviour
{
    public GameObject dotPrefab;
    public float timeBetweenSpawns;
    private float _timeBetweemSpawnsTimer;
    
    

    
    void Update()
    {
        if (_timeBetweemSpawnsTimer <= 0)
        {
            var spawnPosition = Vector3.right * Random.Range(0f,5f) + Vector3.up * Random.Range(0f,10f);
            Instantiate(dotPrefab, spawnPosition , Quaternion.identity);
            _timeBetweemSpawnsTimer = timeBetweenSpawns;

        }
        else
        {
            _timeBetweemSpawnsTimer -= Time.deltaTime;
        }
    }
}
