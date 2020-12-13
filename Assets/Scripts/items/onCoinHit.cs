using UnityEditor;
using UnityEngine;

public class onCoinHit : MonoBehaviour
{
    public Rigidbody2D rb;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (rb.gameObject.tag == other.gameObject.tag)
        {
            Destroy(gameObject);
        }
    }
}

