using System.Collections;
using UnityEditor;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject GameObject;
    public GameObject platform;

    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.relativeVelocity.magnitude);
        //Debug.Log("Collision"); 
        if (rb.gameObject.tag == other.gameObject.tag && rb.velocity.y <= 0)
        {
            var oth_pos = other.gameObject.transform.position;
            Instantiate(platform, new Vector3(oth_pos.x+0.2f, oth_pos.y-0.6f, 0f), Quaternion.identity);
            var _explodable = GetComponent<Explodable>();
            _explodable.explode();
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

