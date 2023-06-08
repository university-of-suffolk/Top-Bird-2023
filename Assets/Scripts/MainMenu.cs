using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public int playerPoints;
    public int aiPoints;

    public GameObject win;
    public GameObject lost;

    private void Start()
    {
        playerPoints = PlayerPrefs.GetInt("PlayerPoints");
        aiPoints = PlayerPrefs.GetInt("AiPoints");

        BackToZero();
    }

    void Update()
    {
        if(playerPoints >= 20)
        {
            win.SetActive(true);                      
        }
        else
        {
            win.SetActive(false);
        }

        if(aiPoints >= 20)
        {            
            lost.SetActive(true);            
        }
        else
        {
            lost.SetActive(false);
        }
    }

    IEnumerator BackToZero()
    {
        yield return new WaitForSeconds(30);

        playerPoints = 0;
        aiPoints = 0;
    }
}
