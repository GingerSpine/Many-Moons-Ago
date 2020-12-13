using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehaviour : MonoBehaviour
{
    public float speedValue;
    public float sizeY;

    private float timeOfDecaying = 5f;
    private float _speed;
    
    void Start()
    {
        _speed = Random.Range(speedValue - 10, speedValue + 10);
        sizeY = speedValue /_speed;
        transform.localScale = Vector3.one + (1- sizeY)*Vector3.up;
    }

    void Update()
    {
        transform.position += _speed * Time.deltaTime * Vector3.up;
        if (timeOfDecaying <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeOfDecaying -= Time.deltaTime;
        }
    }
}
