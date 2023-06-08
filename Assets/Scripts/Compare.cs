using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compare : MonoBehaviour
{
    int aiStatValue;
    int playerStatValue;
    int pointsToWinGameValue;
    public int points;

    public Text playerPoints;
    public Text aiPoints;
    public Text pointsToWinGame;

   
    public void CompareNumbers()
    {
        StartCoroutine(whoWins());        
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

        if (aiStatValue > playerStatValue)
        {
            Debug.Log("AI WINS");
            aiPoints.text = pointsToWinGameValue + " ";
            pointsToWinGame.text = 0 + " ";
        }
        else
        {
            Debug.Log("PLAYER WINS");
            playerPoints.text = pointsToWinGameValue + " ";
            pointsToWinGame.text = 0 + " ";
        }
    }
}
