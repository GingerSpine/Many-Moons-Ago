using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        var platform = GameObject.FindGameObjectsWithTag("platforms").Min(plaftorm => plaftorm.transform.position.y);
        var reset = platform < cameraPosition.position.y;
        if (cameraPosition.position.y > transform.position.y || reset)
        {
            Vector3 newPosition = new Vector3(transform.position.x, cameraPosition.position.y, transform.position.z);
            transform.position = newPosition;
            reset = false;
        }
    }
}
