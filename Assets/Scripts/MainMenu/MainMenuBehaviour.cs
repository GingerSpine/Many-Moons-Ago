using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuBehaviour : MonoBehaviour
{
    public AudioSource ButtonClick;
    public void ExitGame()
    {
        ButtonClick.Play();
        Application.Quit();
    }

    public void OpenSettings()
    {
        ButtonClick.Play();
        SceneManager.LoadScene("Settings");
    }

    public void PlayGame()
    {
        ButtonClick.Play();
        SceneManager.LoadScene("SampleScene");
    }
}
