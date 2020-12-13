using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBehaviour : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
