using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
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

    public Sprite thisSprite;
    public Image thatImage;

    public Image frame;




    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];
    }

    void Update()
    {
        id = thisCard[0].id;
        card_Name = thisCard[0].card_Name;
        wingSpan = thisCard[0].wingSpan;
        speed = thisCard[0].speed;
        strength = thisCard[0].strength;
        weight = thisCard[0].weight;
        size = thisCard[0].size;
        thisSprite = thisCard[0].thisImage;

        nameText.text = " " + card_Name;
        wingspanText.text = "WINGSPAN: " + wingSpan;
        speedText.text = "SPEED: " + speed;
        strengthText.text = "STRENGTH: " + strength;
        weightText.text = "WEIGHT: " + weight;
        sizeText.text = "SIZE: " + size;

        thatImage.sprite = thisSprite;

        if (thisCard[0].color == "Grey")
        {
            frame.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        }

        if (thisCard[0].color == "Blue")
        {
            frame.GetComponent<Image>().color = new Color32(135, 206, 250, 255);
        }

        if (thisCard[0].color == "Red")
        {
            frame.GetComponent<Image>().color = new Color32(220, 20, 60, 255);
        }

        if (thisCard[0].color == "Green")
        {
            frame.GetComponent<Image>().color = new Color32(173, 255, 47, 255);
        }

        if (thisCard[0].color == "Gold")
        {
            frame.GetComponent<Image>().color = new Color32(212, 175, 55, 255);
        }

        if (thisCard[0].color == "Rainbow")
        {
            Material rainbowMaterial = Resources.Load<Material>("Rainbow");
            frame.GetComponent<Image>().material = rainbowMaterial;
        }

    }

}