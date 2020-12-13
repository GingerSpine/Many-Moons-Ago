using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChooseBehaviour : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
