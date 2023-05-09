using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionsScript : MonoBehaviour
{
    public void CollectionsScreen()
    {
        SceneManager.LoadScene("Collections");

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Samplescene");
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}

