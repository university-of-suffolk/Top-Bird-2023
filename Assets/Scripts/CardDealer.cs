using UnityEngine;
using UnityEngine.EventSystems;

public class CardDealer : MonoBehaviour
{
    public Transform playerPanel;    // The panel where player cards are placed
    public Transform aiPanel;        // The panel where AI cards are placed
    public GameObject[] cardPrefabs; // Array of card prefabs

    private DealtCardInfo[] dealtCardInfo; // Store the dealt card information

    private void Start()
    {
        DealCards(); // Deal cards at the start of the game
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
            GameObject playerCard = Instantiate(cardPrefab, playerPanel);
            //EnableCardHover(playerCard); // Enable card hover functionality (commented out)
        }

        // Assign the second half of the shuffled cards to the aiPanel
        for (int i = halfNumCards; i < numCards; i++)
        {
            GameObject cardPrefab = cardPrefabs[i];
            GameObject aiCard = Instantiate(cardPrefab, aiPanel);
            EnableCardCover(aiCard); // Enable card cover
        }

        StoreDealtCardPositions(); // Store the dealt card positions

        DetermineFirstPlayer(); // Determine the first player
    }

    // Restores the positions of the cards
    private void RestoreCardPositions()
    {
        foreach (DealtCardInfo cardInfo in dealtCardInfo)
        {
            cardInfo.card.transform.localPosition = cardInfo.position;
        }
    }

    // Stores the positions of the cards after they are dealt
    private void StoreDealtCardPositions()
    {
        dealtCardInfo = new DealtCardInfo[playerPanel.childCount];

        for (int i = 0; i < playerPanel.childCount; i++)
        {
            Transform card = playerPanel.GetChild(i);
            dealtCardInfo[i].card = card.gameObject;
            dealtCardInfo[i].position = card.localPosition;
        }
    }

    // Enable card cover
    private void EnableCardCover(GameObject card)
    {
        Transform cardCover = card.transform.Find("CardCover");
        if (cardCover != null)
        {
            cardCover.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("CardCover component not found on the card.");
        }
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

    private struct DealtCardInfo
    {
        public GameObject card;
        public Vector3 position;
    }
}
