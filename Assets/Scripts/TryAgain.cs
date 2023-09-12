using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("The Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
