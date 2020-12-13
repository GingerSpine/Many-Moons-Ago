using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehaviour : MonoBehaviour
{
    public float timeBeforeDestroy;
    
    void Update()
    {
        if (timeBeforeDestroy <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeBeforeDestroy -= Time.deltaTime;
        }
    }
}
