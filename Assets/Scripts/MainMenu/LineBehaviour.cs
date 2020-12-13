using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehaviour : MonoBehaviour
{
    public float speedValue;
    public float sizeY;

    private float timeOfDecaying = 2f;
    private float _speed;
    
    void Start()
    {
        _speed = Random.Range(speedValue-500, speedValue + 500);
        sizeY = speedValue /_speed;
        transform.localScale = Vector3.up * sizeY;
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
