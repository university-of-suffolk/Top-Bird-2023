using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Stats of the card
    public enum Stats
    {
        Wingspan,
        Speed,
        Strength,
        Weight,
        Size
    }

    //Categories of the card
    public enum Category
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Rainbow
    }

    public string cardName;
    public Stats wingspanStat;
    public int wingspanValue;
    public Stats speedStat;
    public int speedValue;
    public Stats strengthStat;
    public int strengthValue;
    public Stats weightStat;
    public int weightValue;
    public Stats sizeStat;
    public int sizeValue;
    public Category category;
    public int scoreMultiplier;

    // Constructor to initialise card properties
    public Card(string name, Stats wStat, int wValue, Stats sStat, int sValue, Stats strStat, int strValue, Stats wtStat, int wtValue, Stats szStat, int szValue, Category cat, int multi)
    {
        cardName = name;
        wingspanStat = wStat;
        wingspanValue = wValue;
        speedStat = sStat;
        speedValue = sValue;
        strengthStat = strStat;
        strengthValue = strValue;
        weightStat = wtStat;
        weightValue = wtValue;
        sizeStat = szStat;
        sizeValue = szValue;
        category = cat;
        scoreMultiplier = multi;
    }

    //Get the multiplier for the given stat
    public int GetMultiplier(Stats stat)
    {
        int[] values = { wingspanValue, speedValue, strengthValue, weightValue, sizeValue };
        int index = -1;
        for (int i = 0; i < values.Length; i++)
        {
            if (stat.ToString() == System.Enum.GetName(typeof(Stats), i ))
            {
                index = i;
                break;
            }
        }

        if (index == -1) return 0;

        int[] sortedValues = (int[])values.Clone();
        System.Array.Sort(sortedValues);
        int rank = System.Array.IndexOf(sortedValues, values[index]) + 1;

        switch (rank)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 3;
            case 4:
                return 4;
            case 5:
                return 5;
            default:
                return 0;
        }
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Card : MonoBehaviour
//{
//    public string cardName;
//    public int wingspan;
//    public int speed;
//    public int strength;
//    public int weight;
//    public int size;
//    public int scoreMultiplier;

//    //constructor to initialise card properties
//    public Card(string name, int wspan, int spd, int str, int wgt, int sz, int multi)
//    {
//        cardName = name;
//        wingspan = wspan;
//        speed = spd;
//        strength = str;
//        weight = wgt;
//        size = sz;
//        scoreMultiplier = multi;
//    }
//}