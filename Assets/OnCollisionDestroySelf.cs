using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDestroySelf : MonoBehaviour
{
    public GameObject GameObject;
    void OnCollisionStart2D(Collision2D other)
    {
        if (GameObject.tag == other.gameObject.tag)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}

