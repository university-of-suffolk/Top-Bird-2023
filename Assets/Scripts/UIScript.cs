using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This script will handle the game's user interface, such as displaying the cards, scores, and other relevant information.


public class UI : MonoBehaviour
{
    public Text playerScoreText;
    public Text aiScoreText;
    public Text playerCategoryText;
    public Text aiCategoryText;
    public Text winnerText;
    public Button higherButton;
    public Button lowerButton;

    public void UpdateScore(int playerScore, int aiScore)
    {
        playerScoreText.text = "Player: " + playerScore.ToString();
        aiScoreText.text = "AI: " + aiScore.ToString();
    }

    public void UpdateSelectedCategory(int categoryIndex)
    {
        string categoryName = "";
        switch (categoryIndex)
        {
            case 0:
                categoryName = "Uncommon";
                break;
            case 1:
                categoryName = "Rare";
                break;
            case 2:
                categoryName = "Epic";
                break;
            case 3:
                categoryName = "Legendary";
                break;
            case 4:
                categoryName = "Rainbow";
                break;
        }
        playerCategoryText.text = "Player: " + categoryName;
        aiCategoryText.text = "AI: " + categoryName;
    }

    public void UpdateWinner(string winner)
    {
        winnerText.text = winner + " wins!";
    }

    public void EnableButtons(bool enable)
    {
        higherButton.interactable = enable;
        lowerButton.interactable = enable;
    }
}
