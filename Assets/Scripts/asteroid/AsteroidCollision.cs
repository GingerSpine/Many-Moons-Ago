using System.Collections;
using UnityEditor;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject GameObject;

    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.relativeVelocity.magnitude);
        //Debug.Log("Collision"); 
        if (rb.gameObject.tag == other.gameObject.tag && rb.velocity.y <= 0)
        {
            var _explodable = GetComponent<Explodable>();
            _explodable.explode();
            ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
            ef.doExplosion(transform.position);
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(4);
        Destroy(GameObject);
    }
}

