using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Compare : MonoBehaviour
{
    int aiStatValue;
    int playerStatValue;
    int pointsToWinGameValue;
    int aiPointsToWinGameValue;
    public static int points;
    static int pointsAi;

    public Text playerPoints;
    public Text aiPoints;
    public Text pointsToWinGame;
    public Text aiPointsToWin;

    private void Start()
    {
        PlayerPrefs.GetInt("PlayerPoints");
        PlayerPrefs.GetInt("AiPoints");
    }
    public void CompareNumbers()
    {        
        StartCoroutine(whoWins());        
    }

    private void Update()
    {
        playerPoints.text = points + "";
        aiPoints.text = pointsAi + "";

        if(points >= 20)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if(pointsAi >= 20)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public IEnumerator whoWins()
    {
        yield return new WaitForSeconds(0.1f);

        

        Text aiStat = GameObject.Find("aiStatNameText").GetComponent<Text>();
        aiStatValue = int.Parse(aiStat.text);

        Text playerStat = GameObject.Find("playerStatNameText").GetComponent<Text>();
        playerStatValue = int.Parse(playerStat.text);

        pointsToWinGame.GetComponent<Text>();
        pointsToWinGameValue = int.Parse(pointsToWinGame.text);

        aiPointsToWin.GetComponent<Text>();
        aiPointsToWinGameValue = int.Parse(aiPointsToWin.text);

        if (aiStatValue > playerStatValue)
        {
            Debug.Log("AI WINS");
            pointsAi += aiPointsToWinGameValue;
            aiPoints.text = pointsAi + "";
            PlayerPrefs.SetInt("AiPoints", pointsAi);
            aiPointsToWin.text = 0 + " ";
        }
        else
        {
            Debug.Log("PLAYER WINS");
            points += pointsToWinGameValue;
            playerPoints.text = points + "";
            PlayerPrefs.SetInt("PlayerPoints", points);
            pointsToWinGame.text = 0 + " ";
        }

        StartCoroutine(ResetGame());
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("Game");
    }
}
