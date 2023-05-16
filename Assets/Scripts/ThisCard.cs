using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();

    // Assign the player-specific UI elements in the inspector
    public Text nameText;
    public Text wingspanText;
    public Text speedText;
    public Text strengthText;
    public Text weightText;
    public Text sizeText;

    public Image cardImage;
    public Image frame;

    public bool cardBack;
    public static bool staticCardBack;

    public int thisId;

    void Start()
    {
        // Check if there are enough cards in the card database
        if (CardDataBase.cardList.Count < 32)
        {
            Debug.LogError("Insufficient cards in the database.");
            return;
        }

        // Shuffle the card database
        List<Card> shuffledCards = ShuffleCards(CardDataBase.cardList);

        // Assign the first 16 cards to the player
        for (int i = 0; i < 16; i++)
        {
            thisCard.Add(shuffledCards[i]);
        }
    }

    void Update()
    {
        if (thisCard.Count > 0)
        {
            Card currentCard = thisCard[0];

            nameText.text = " " + currentCard.card_Name;
            wingspanText.text = "WINGSPAN: " + currentCard.wingSpan;
            speedText.text = "SPEED: " + currentCard.speed;
            strengthText.text = "STRENGTH: " + currentCard.strength;
            weightText.text = "WEIGHT: " + currentCard.weight;
            sizeText.text = "SIZE: " + currentCard.size;

            cardImage.sprite = currentCard.thisImage;

            if (frame != null && currentCard.color != null)
            {
                switch (currentCard.color)
                {
                    case "Grey":
                        frame.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
                        break;
                    case "Blue":
                        frame.GetComponent<Image>().color = new Color32(135, 206, 250, 255);
                        break;
                    case "Red":
                        frame.GetComponent<Image>().color = new Color32(220, 20, 60, 255);
                        break;
                    case "Green":
                        frame.GetComponent<Image>().color = new Color32(173, 255, 47, 255);
                        break;
                    case "Gold":
                        frame.GetComponent<Image>().color = new Color32(212, 175, 55, 255);
                        break;
                    case "Rainbow":
                        Material rainbowMaterial = Resources.Load<Material>("Rainbow");
                        frame.GetComponent<Image>().material = rainbowMaterial;
                        break;
                }
            }
            else
            {
                Debug.LogError("Frame or color reference is null!");
            }
        }
        else
        {
            Debug.LogError("thisCard List is EMPTY!");
        }

        staticCardBack = cardBack;
    }

    List<Card> ShuffleCards(List<Card> cards)
    {
        List<Card> shuffledCards = new List<Card>(cards);
        for (int i = shuffledCards.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Card temp = shuffledCards[i];
            shuffledCards[i] = shuffledCards[randomIndex];
            shuffledCards[randomIndex] = temp;
        }
        return shuffledCards;
    }
}