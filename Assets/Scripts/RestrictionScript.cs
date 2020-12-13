using UnityEngine;
using UnityEngine.SceneManagement;

public class RestrictionScript : MonoBehaviour {

    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == rb.tag)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
