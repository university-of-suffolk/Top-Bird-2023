using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public Transform playerPanel;
    public Transform aiPanel;
    public GameObject[] cardPrefabs;

    private void Start()
    {
        DealCards();
    }

    public void DealCards()
    {
        int numCards = cardPrefabs.Length;
        int halfNumCards = numCards / 2;

        // Shuffle the cardPrefabs array using Fisher-Yates shuffle algorithm
        for (int i = 0; i < numCards - 1; i++)
        {
            int randomIndex = Random.Range(i, numCards);
            GameObject temp = cardPrefabs[randomIndex];
            cardPrefabs[randomIndex] = cardPrefabs[i];
            cardPrefabs[i] = temp;
        }

        // Assign the first half of the shuffled cards to the playerPanel
        for (int i = 0; i < halfNumCards; i++)
        {
            GameObject cardPrefab = cardPrefabs[i];
            Instantiate(cardPrefab, playerPanel);
        }

        // Assign the second half of the shuffled cards to the aiPanel
        for (int i = halfNumCards; i < numCards; i++)
        {
            GameObject cardPrefab = cardPrefabs[i];
            Instantiate(cardPrefab, aiPanel);
        }

        DetermineFirstPlayer();
    }

    private enum Turn
    {
        Player,
        AI
    }

    private Turn currentPlayer;

    private void DetermineFirstPlayer()
    {
        currentPlayer = (Turn)Random.Range(0, 2);

        if (currentPlayer == Turn.AI)
        {
            AIturn();
        }
    }

    public void PlayerTurn(GameObject card)
    {
        GameController gameController = FindObjectOfType<GameController>();
        gameController.StartPlayerTurn(card);
    }

    private void AIturn()
    {
        GameController gameController = FindObjectOfType<GameController>();
        gameController.StartAITurn(aiPanel.gameObject);
    }




}