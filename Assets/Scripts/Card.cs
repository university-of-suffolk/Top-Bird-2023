using UnityEngine;

public class Card
{
    public int cardIndex;
    public string cardName;
    public int speed;
    public int size;
    public int strength;
    public int weight;
    public int wingspan;
    public Sprite cardImage;
    public string baseColor;

    public Card(int index, string name, int spd, int sz, int str, int wt, int wspn, Sprite img, string color)
    {
        cardIndex = index;
        cardName = name;
        speed = spd;
        size = sz;
        strength = str;
        weight = wt;
        wingspan = wspn;
        cardImage = img;
        baseColor = color;
    }
}
