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

    public bool playerGoesFirst = true; // Flag to determine if the player goes first or not
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

    public IEnumerator AITurnCoroutine()
    {
        aiTurnIndicator.SetActive(true); // Show AI turn indicator

        yield return new WaitForSeconds(1f); // Delay to simulate AI thinking

        // Print the number of cards in the AI's panel
        Debug.Log("AI Panel Count: " + aiPanel.transform.childCount);

        GameObject randomCard;
        string selectedStatName;

        if (playerGoesFirst)
        {
            // Player goes first, AI selects a random card and the same named stat
            if (aiPanel.transform.childCount > 0)
            {
                randomCard = aiPanel.transform.GetChild(Random.Range(0, aiPanel.transform.childCount)).gameObject;
            }
            else
            {
                Debug.LogWarning("No cards in AI panel!");
                yield break; // Exit the coroutine if there are no cards in the AI panel
            }

            selectedStatName = cardPrefabs[0].transform.Find("Text/" + statNameText.text).name;
        }
        else
        {
            // AI goes first, player selects a card and the AI selects the predetermined stat
            // Here, you can implement the logic to allow the player to select a card
            // and assign the selectedStatName variable with the predetermined stat name.
            // For simplicity, let's assume the predetermined stat is "Speed" for this example.
            selectedStatName = "Speed";
            if (aiPanel.transform.childCount > 0)
            {
                randomCard = aiPanel.transform.GetChild(Random.Range(0, aiPanel.transform.childCount)).gameObject;
            }
            else
            {
                Debug.LogWarning("No cards in AI panel!");
                yield break; // Exit the coroutine if there are no cards in the AI panel
            }
        }

        // Rest of the code...
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

    public void StartPlayerTurn()
    {
        Debug.Log("Starting players turn ...");
    }
}
