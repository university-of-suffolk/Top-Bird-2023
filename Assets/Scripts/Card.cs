using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    
    public Card()
    {

    }

    public Card(int Id, string CardName,int Wingspan, int Speed, int Strength, int Weight, int Size)
    {
        id = Id;
        card_Name = CardName;
        wingSpan = Wingspan;
        speed = Speed;
        strength = Strength;
        weight = Weight;
        size = Size;
    }
}
