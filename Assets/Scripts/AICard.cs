using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string card_Name;
    public int wingSpan;
    public int speed;
    public int strength;
    public int weight;
    public int size;

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

    public Image cardBackImage;

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
            id = thisCard[0].id;
            card_Name = thisCard[0].card_Name;
            wingSpan = thisCard[0].wingSpan;
            speed = thisCard[0].speed;
            strength = thisCard[0].strength;
            weight = thisCard[0].weight;
            size = thisCard[0].size;

            nameText.text = " " + card_Name;
            wingspanText.text = "WINGSPAN: " + wingSpan;
            speedText.text = "SPEED: " + speed;
            strengthText.text = "STRENGTH: " + strength;
            weightText.text = "WEIGHT: " + weight;
            sizeText.text = "SIZE: " + size;

            // Display either card front or card back image
            if (staticCardBack)
            {
                cardImage.sprite = cardBackImage.sprite; // Display card back image
                frame.GetComponent<Image>().color = Color.white; // Reset frame color
            }
            else
            {
                cardImage.sprite = thisCard[0].thisImage; // Display card front image

                if (frame != null && thisCard[0].color != null)
                {
                    if (thisCard[0].color == "Grey")
                    {
                        frame.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
                    }
                    else if (thisCard[0].color == "Blue")
                    {
                        frame.GetComponent<Image>().color = new Color32(135, 206, 250, 255);
                    }
                    else if (thisCard[0].color == "Red")
                    {
                        frame.GetComponent<Image>().color = new Color32(220, 20, 60, 255);
                    }
                    else if (thisCard[0].color == "Green")
                    {
                        frame.GetComponent<Image>().color = new Color32(173, 255, 47, 255);
                    }
                    else if (thisCard[0].color == "Gold")
                    {
                        frame.GetComponent<Image>().color = new Color32(212, 175, 55, 255);
                    }
                    else if (thisCard[0].color == "Rainbow")
                    {
                        Material rainbowMaterial = Resources.Load<Material>("Rainbow");
                        frame.GetComponent<Image>().material = rainbowMaterial;
                    }
                }
                else
                {
                    Debug.LogError("Frame or color reference is null!");
                }
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
