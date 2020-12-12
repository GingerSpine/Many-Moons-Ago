using UnityEditor;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public float jumpForce = 10f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = 0;
                rb.velocity = velocity;
            }
        }


    }


}

