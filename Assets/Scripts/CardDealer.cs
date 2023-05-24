using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDealer : MonoBehaviour
{
    public GameObject playerPanel;
    public GameObject aiPanel;
    public List<GameObject> cardPrefabs; // List of card prefabs
    public GameObject aiTurnIndicator; // Reference to the AI turn indicator UI object

    private bool playerGoesFirst = true; // Flag to determine if the player goes first or not
    public Text statNameText;

    private void Start()
    {
        DealCards();

        if (!playerGoesFirst)
        {
            StartCoroutine(AITurnCoroutine());
        }
    }


    private void DealCards()
    {
        int numCards = cardPrefabs.Count;
        int numCardsPerPlayer = numCards / 2; // Divide the cards equally between players

        // Shuffle the cards
        Shuffle(cardPrefabs);

        // Deal cards to the player
        for (int i = 0; i < numCardsPerPlayer; i++)
        {
            GameObject cardPrefab = cardPrefabs[i];
            InstantiateCard(cardPrefab, playerPanel.transform);
        }

        // Deal cards to the AI
        bool aiHasCard32 = false; // Flag to track if the AI has Card32
        for (int i = numCardsPerPlayer; i < numCards; i++)
        {
            GameObject cardPrefab = cardPrefabs[i];
            InstantiateCard(cardPrefab, aiPanel.transform);

            // Check if the AI has Card32
            if (cardPrefab.name == "Card32")
            {
                aiHasCard32 = true;
            }
        }

        // Start the AI turn if it has Card32
        if (aiHasCard32)
        {
            StartCoroutine(AITurnCoroutine());
        }
    }




    private void InstantiateCard(GameObject cardPrefab, Transform parent)
    {
        GameObject cardObject = Instantiate(cardPrefab, parent);
        CardUI cardUI = cardObject.GetComponent<CardUI>();
        if (cardUI != null)
        {
            cardUI.ScaleDown(0.75f); // Scale down the card UI

            if (parent == aiPanel.transform)
            {
                GameObject cardCover = cardObject.transform.Find("CardCover").gameObject;
                cardCover.SetActive(true); // Enable the CardCover GameObject
            }
        }
    }



    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private IEnumerator AITurnCoroutine()
{
    aiTurnIndicator.SetActive(true); // Show AI turn indicator

    yield return new WaitForSeconds(1f); // Delay to simulate AI thinking

    // Print the number of cards in the AI's panel
    Debug.Log("AI Panel Count: " + aiPanel.transform.childCount);

    // Select a random card from the AI's panel
    int numCards = aiPanel.transform.childCount;
    int randomIndex = Random.Range(0, numCards);
    GameObject randomCard = aiPanel.transform.GetChild(randomIndex).gameObject;

    // Disable the CardCover game object
    GameObject cardCover = randomCard.transform.Find("CardCover").gameObject;
    cardCover.SetActive(false);

    // Move the card to the left middle of the screen
    StartCoroutine(MoveCardToPosition(randomCard.transform, new Vector3(-4f, 0f, 0f), 1f));

    aiTurnIndicator.SetActive(false); // Hide AI turn indicator

    // Select a random stat from the card
    int numStats = randomCard.transform.Find("Stats").childCount;
    int randomStatIndex = Random.Range(0, numStats);
    Transform stat = randomCard.transform.Find("Stats").GetChild(randomStatIndex);
    Text statText = stat.GetComponent<Text>(); // Get the Text component
    int statValue = int.Parse(statText.text);
    string statName = statText.name.Replace("Text", "").Replace("Stat", ""); // Remove "Text" and "Stat" from the name

    Debug.Log("AI selected Card: " + randomCard.name + " Stat: " + statName + " Value: " + statValue);

    // Update the UI Text with the selected stat name
    statNameText.text = statName + ": " + statValue;

    // TODO: Implement the logic to compare the selected card with the player's card and determine the winner

    // TODO: Implement the logic to switch turns between the player and the AI

    // Example code to end the game after the AI's turn
    // yield return new WaitForSeconds(2f); // Delay to show the result
    // EndGame();
}




    private IEnumerator MoveCardToPosition(Transform cardTransform, Vector3 targetPosition, float moveDuration)
    {
        // Store the initial and target scales of the card
        Vector3 initialScale = cardTransform.localScale;
        Vector3 targetScale = initialScale * 1.25f;

        // Move the card to the target position while increasing its size
        float elapsedTime = 0f;
        Vector3 startPosition = cardTransform.position;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            cardTransform.position = Vector3.Lerp(startPosition, targetPosition, t);
            cardTransform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        // Set the scale of the card to the final target scale
        cardTransform.localScale = targetScale;
    }

}
