using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroBehaviour : MonoBehaviour
{
    public float timeBeforeDiying;
    void Update()
    {
        if (timeBeforeDiying <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            timeBeforeDiying -= Time.deltaTime;
        }
    }
}
