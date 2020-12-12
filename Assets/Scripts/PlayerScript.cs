using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    private TrajectoryController trajectoryController;
    private bool isPulling;
    private Vector3 startPosition;

    public float maxMouseDelta;
    public float multiplier;

    private bool IsNoVelocity => rb.velocity.x == 0 && rb.velocity.y == 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trajectoryController = GetComponent<TrajectoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isPulling && IsNoVelocity)
            {
                isPulling = true;
                startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (isPulling)
            {
                var diffPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPosition;
                var velocity = rb.velocity;
                velocity.y = -diffPosition.y * multiplier;
                velocity.x = -diffPosition.x * multiplier;
                trajectoryController.velocity = velocity;
                //Debug.DrawRay(transform.position, worldPoint, Color.green);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isPulling)
            {
                var diffPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPosition;

                UpdateVelocty(-diffPosition.x * multiplier, -diffPosition.y * multiplier);
                isPulling = false;
            }
        }

    }

    private void FixedUpdate()
    {
    }

    private void UpdateVelocty(float? x = null, float? y = null)
    {
        var velocity = rb.velocity;
        if (y.HasValue)
        {
            velocity.y = y.Value;
        }
        if (x.HasValue)
        {
            velocity.x = x.Value;
        }
        rb.velocity = velocity;
    }
}
