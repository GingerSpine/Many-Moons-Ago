using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersFollowing : MonoBehaviour
{
    public Transform cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraPosition.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, cameraPosition.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
