using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card : MonoBehaviour
{
    public int id;
    public string card_Name;
    public int wingSpan;
    public int speed;
    public int strength;
    public int weight;
    public int size;

    public Sprite thisImage;

    public string color;
        

    public Card()
    {

    }

    public Card(int Id, string CardName,int Wingspan, int Speed, int Strength, int Weight, int Size, Sprite ThisImage, string Color)
    {
        id = Id;
        card_Name = CardName;
        wingSpan = Wingspan;
        speed = Speed;
        strength = Strength;
        weight = Weight;
        size = Size;
        thisImage = ThisImage;
        color = Color;
    }
}
