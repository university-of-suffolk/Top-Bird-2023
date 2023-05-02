using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}