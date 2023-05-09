using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will define a deck of cards and how they are shuffled and dealt to the players.


public class Deck : MonoBehaviour
{
    // Card prefab to instantiate
    public GameObject cardPrefab;

    // List of cards in the deck
    private List<Card> cards = new List<Card>();

    // Initialize the deck with cards
    public void InitializeDeck(int numCards)
    {
        // Create cards and add them to the list
        for (int i = 0; i < numCards; i++)
        {
            Card newCard = Instantiate(cardPrefab, transform).GetComponent<Card>();
            newCard.cardID = i;
            newCard.cardName = "Card " + i;
            newCard.uncommonValue = Random.Range(1, 11);
            newCard.rareValue = Random.Range(1, 11);
            newCard.epicValue = Random.Range(1, 11);
            newCard.legendaryValue = Random.Range(1, 11);
            newCard.rainbowValue = Random.Range(1, 11);
            cards.Add(newCard);
        }
    }

    // Shuffle the deck
    public void ShuffleDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    // Deal a card from the deck
    public Card DealCard()
    {
        Card dealtCard = cards[0];
        cards.RemoveAt(0);
        return dealtCard;
    }

    // Check if the deck is empty
    public bool IsEmpty()
    {
        return cards.Count == 0;
    }
}
