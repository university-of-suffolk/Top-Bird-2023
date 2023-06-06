using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void GameScreen()
    {
        // Loads the "Game" scene
        SceneManager.LoadScene("Game");
    }

 
}