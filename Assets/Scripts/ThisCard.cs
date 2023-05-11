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

        nameText.text = " " + card_Name;
        wingspanText.text = " " + wingSpan;
        speedText.text = " " + speed;
        strengthText.text = " " + strength;
        weightText.text = " " + weight;
        sizeText.text = " " + size;

    }

}