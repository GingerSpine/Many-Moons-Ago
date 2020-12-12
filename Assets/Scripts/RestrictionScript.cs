using UnityEngine;
using UnityEngine.SceneManagement;

public class RestrictionScript : MonoBehaviour {

    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
