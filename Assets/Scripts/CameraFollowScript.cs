using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform cameraPosition;
    public float smoothmoveSpeed = 0.3f;
    public float allowedOffset = 0.3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(cameraPosition.position.x, cameraPosition.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
