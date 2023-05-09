using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public void SettingScreen()
    {
        SceneManager.LoadScene("Settings");

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Samplescene");
    }

}

