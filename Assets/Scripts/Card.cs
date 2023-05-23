using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card : MonoBehaviour
{

    public int id;
    public string cardName;
    public int wingspan;
    public int size;
    public int strength;
    public int weight;
    public int speed;

    public Sprite thisImage;
    public string color;

    public Card()
    {

    }

    public Card (int Id, string CardName, int Wingspan, int Size, int Strength, int Weight, int Speed, Sprite ThisImage, string Color)
    {
        id = Id;
        cardName = CardName;
        wingspan = Wingspan;
        size = Size;
        strength = Strength;
        weight = Weight;
        speed = Speed;
        thisImage = ThisImage;
        color = Color;
    }

 
}
