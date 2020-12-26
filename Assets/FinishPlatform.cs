using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPlatform : MonoBehaviour
{
    public Rigidbody2D rb;

    void OnCollisionStay2D(Collision2D other)
    {
        if (rb.gameObject.tag == other.gameObject.tag && rb.velocity.y <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
