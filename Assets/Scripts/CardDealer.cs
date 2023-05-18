using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public GameObject playerPanel;
    public GameObject aiPanel;
    public List<GameObject> cardPrefabs; // List of card prefabs

    private void Start()
    {
        DealCards();
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
        for (int i = numCardsPerPlayer; i < numCards; i++)
        {
            GameObject cardPrefab = cardPrefabs[i];
            InstantiateCard(cardPrefab, aiPanel.transform);
        }
    }

    private void InstantiateCard(GameObject cardPrefab, Transform parent)
    {
        GameObject cardObject = Instantiate(cardPrefab, parent);
        CardUI cardUI = cardObject.GetComponent<CardUI>();
        if (cardUI != null)
        {
            cardUI.ScaleDown(0.5f); // Scale down the card UI
            // Additional setup or modifications to the instantiated card UI, if needed
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
}
