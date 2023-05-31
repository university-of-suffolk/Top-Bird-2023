using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private void Start()
    {        
        Transform speedStat = gameObject.transform.Find("Stats").transform.Find("SpeedStatText");
        Text speedStatText = speedStat.GetComponent<Text>(); // Get the Text component
        int speedStatValue = int.Parse(speedStatText.text);

        Transform sizeStat = gameObject.transform.Find("Stats").transform.Find("SizeStatText");
        Text sizeStatText = sizeStat.GetComponent<Text>(); // Get the Text component
        int sizeStatValue = int.Parse(sizeStatText.text);

        Transform weightStat = gameObject.transform.Find("Stats").transform.Find("WeightStatText");
        Text weightStatText = weightStat.GetComponent<Text>(); // Get the Text component
        int weightStatValue = int.Parse(weightStatText.text);

        Transform strengthStat = gameObject.transform.Find("Stats").transform.Find("StrengthStatText");
        Text strengthStatText = strengthStat.GetComponent<Text>(); // Get the Text component
        int strengthStatValue = int.Parse(strengthStatText.text);

        Transform wingspanStat = gameObject.transform.Find("Stats").transform.Find("WingspanStatText");
        Text wingspanStatText = wingspanStat.GetComponent<Text>(); // Get the Text component
        int wingspanStatValue = int.Parse(wingspanStatText.text);

        int[] pointOrder = new int[] { speedStatValue, sizeStatValue, weightStatValue, strengthStatValue, wingspanStatValue };
                
        Array.Sort(pointOrder);
        foreach(int i in pointOrder)
        {
            Debug.Log(i + " ");
        }        
    }
}
