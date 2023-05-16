using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();

    public int deckSize = 16;

    public GameObject playerCardPrefab;
    public GameObject aiCardPrefab;
    public Transform playerCardPanelTransform;
    public Transform aiCardPanelTransform;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < deckSize; i++)
        {
            deck.Add(CardDataBase.cardList[i]);
        }

        Shuffle();

        for (int i = 0; i < deckSize; i++)
        {
            Card card = deck[i];

            GameObject playerCard = Instantiate(playerCardPrefab, playerCardPanelTransform);
            ThisCard playerCardScript = playerCard.GetComponent<ThisCard>();

            Card playerCardData = new Card(card.id, card.card_Name, card.wingSpan, card.speed, card.strength, card.weight, card.size, card.thisImage, card.color);
            playerCardScript.thisCard.Add(playerCardData);
            playerCardScript.thisId = playerCardData.id;
            playerCardScript.cardBack = false;

            GameObject aiCard = Instantiate(aiCardPrefab, aiCardPanelTransform);

            if (aiCard != null)
            {
                ThisCard aiCardScript = aiCard.GetComponent<ThisCard>();
                Card aiCardData = new Card(card.id, card.card_Name, card.wingSpan, card.speed, card.strength, card.weight, card.size, card.thisImage, card.color);
                aiCardScript.thisCard.Add(aiCardData);
                aiCardScript.thisId = aiCardData.id;
                aiCardScript.cardBack = true;
            }
            else
            {
                Debug.LogError("AI Card is not assigned. Make sure you have a valid AI card panel assigned.");
            }
        }
    }

    public void Shuffle()
    {
        int n = deckSize;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }
}
