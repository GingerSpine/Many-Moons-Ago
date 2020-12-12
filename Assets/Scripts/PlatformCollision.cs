using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    public BordersFollowing bordersFollowing;
    public GameObject platformPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (platformPrefab.tag == "platforms")
        {
            //Destroy(platformPrefab);
        }
    }
}
