﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenScript : MonoBehaviour
{

    public GameObject platformPrefab;
    public float numberofPlatform;
    public float levelWidth;
    public float minY;
    public float maxY;
    public int InRow = 2;
    public GameObject[] Asteroids;
    public float itemSpawnPercent = 100;
    public GameObject[] ItemToSpawn;
    public GameObject Player;
    public GameObject FinishPlatform;

    private int baseCountOfAsteroids = 40;
    private Vector3 lastSpawnPosition;
    private int lastRowNumber = 0;

    // Use this for initialization
    void Start()
    {
        lastSpawnPosition = new Vector3();
        generate_platforms();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y >= (lastSpawnPosition.y - 5 * ((minY + maxY) / 2)))
        {
            generate_platforms();
        }
    }

    void generate_platforms()
    {
        // test

        for (int i = 0; i <= baseCountOfAsteroids; i++, lastRowNumber++)
        {
            lastSpawnPosition.y += Random.Range(minY, maxY);
            if (lastRowNumber % 6 == 0 && lastRowNumber > 2)
            {

                lastSpawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(FinishPlatform, lastSpawnPosition, Quaternion.identity);
            }
            for (int j = 0; j < InRow; j++)
            {

                lastSpawnPosition.x = Random.Range(-levelWidth, levelWidth);
                
                if (Random.Range(0, 100) <= 45 || j == 0)
                {
                    i++;
                    Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], lastSpawnPosition, Quaternion.identity);
                    if (Random.Range(0, 100) <= itemSpawnPercent)
                    {
                        Instantiate(ItemToSpawn[Random.Range(0, ItemToSpawn.Length)], new Vector3(lastSpawnPosition.x, lastSpawnPosition.y + 1.6f, 0f), Quaternion.identity);

                    }
                }
            }

        }
    }
}
