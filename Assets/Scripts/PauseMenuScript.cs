using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public Audio audioManager;
    private AudioSource audioSource;

    public Texture2D cursorTex;

    public GameObject settingsMenu;
    public GameObject controlsMenu;



    private void Start()
    {
        audioSource = audioManager.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        audioSource.Play();
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.Auto);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        audioSource.Pause();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Settings()
    {

    }

    public void Controls()
    {

    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
