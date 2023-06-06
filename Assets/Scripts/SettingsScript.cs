using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public void SettingScreen()
    {
        // Loads the "Settings" scene
        SceneManager.LoadScene("Settings");
    }

    public void ReturnToMenu()
    {
        // Loads the "Samplescene" scene
        SceneManager.LoadScene("Samplescene");
    }
}
