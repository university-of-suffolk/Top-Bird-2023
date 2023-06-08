using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestPoints : MonoBehaviour
{
    GameObject go;

    public int points;
    public int[] pointOrder;
    int speedStatValue;
    int sizeStatValue;
    int weightStatValue;
    int strengthStatValue;
    int wingspanStatValue;
        
    public Text statText;
    public Text pointsToWin;

    private void Start()
    {
        go = GameObject.Find("Go");
        go.GetComponent<Image>();        

        Transform speedStat = gameObject.transform.Find("Stats").transform.Find("SpeedStatText");
        Text speedStatText = speedStat.GetComponent<Text>(); // Get the Text component
        speedStatValue = int.Parse(speedStatText.text);

        Transform sizeStat = gameObject.transform.Find("Stats").transform.Find("SizeStatText");
        Text sizeStatText = sizeStat.GetComponent<Text>(); // Get the Text component
        sizeStatValue = int.Parse(sizeStatText.text);

        Transform weightStat = gameObject.transform.Find("Stats").transform.Find("WeightStatText");
        Text weightStatText = weightStat.GetComponent<Text>(); // Get the Text component
        weightStatValue = int.Parse(weightStatText.text);

        Transform strengthStat = gameObject.transform.Find("Stats").transform.Find("StrengthStatText");
        Text strengthStatText = strengthStat.GetComponent<Text>(); // Get the Text component
        strengthStatValue = int.Parse(strengthStatText.text);

        Transform wingspanStat = gameObject.transform.Find("Stats").transform.Find("WingspanStatText");
        Text wingspanStatText = wingspanStat.GetComponent<Text>(); // Get the Text component
        wingspanStatValue = int.Parse(wingspanStatText.text);

        pointOrder = new int[] { speedStatValue, sizeStatValue, weightStatValue, strengthStatValue, wingspanStatValue };

        Array.Sort(pointOrder);        
    }   

    public void Speed()
    {
        statText.text = " " + speedStatValue;

        go.GetComponent<Image>().enabled = true;
        
        if (speedStatValue == pointOrder[0])
        {
            points = 5;
            pointsToWin.text = points + " ";         
            
        }

        if (speedStatValue == pointOrder[1])
        {
            points = 4;
            pointsToWin.text = points + " ";
        }

        if (speedStatValue == pointOrder[2])
        {
            points = 3;
            pointsToWin.text = points + " ";
        }

        if (speedStatValue == pointOrder[3])
        {
            points = 2;
            pointsToWin.text = points + " ";
        }

        if (speedStatValue == pointOrder[4])
        {
            points = 1;
            pointsToWin.text = points + " ";
        }
    }

    public void Size()
    {
        statText.text = " " + sizeStatValue;

        go.GetComponent<Image>().enabled = true;

        if (sizeStatValue == pointOrder[0])
        {
            points = 5;
            pointsToWin.text = points + " ";
        }

        if (sizeStatValue == pointOrder[1])
        {
            points = 4;
            pointsToWin.text = points + " ";
        }

        if (sizeStatValue == pointOrder[2])
        {
            points = 3;
            pointsToWin.text = points + " ";
        }

        if (sizeStatValue == pointOrder[3])
        {
            points = 2;
            pointsToWin.text = points + " ";
        }

        if (sizeStatValue == pointOrder[4])
        {
            points = 1;
            pointsToWin.text = points + " ";
        }
    }

    public void Weight()
    {
        statText.text = " " + weightStatValue;

        go.GetComponent<Image>().enabled = true;

        if (weightStatValue == pointOrder[0])
        {
            points = 5;
            pointsToWin.text = points + " ";
        }

        if (weightStatValue == pointOrder[1])
        {
            points = 4;
            pointsToWin.text = points + " ";
        }

        if (weightStatValue == pointOrder[2])
        {
            points = 3;
            pointsToWin.text = points + " ";
        }

        if (weightStatValue == pointOrder[3])
        {
            points = 2;
            pointsToWin.text = points + " ";
        }

        if (weightStatValue == pointOrder[4])
        {
            points = 1;
            pointsToWin.text = points + " ";
        }
    }

    public void Strength()
    {
        statText.text = " " + strengthStatValue;

        go.GetComponent<Image>().enabled = true;

        if (strengthStatValue == pointOrder[0])
        {
            points = 5;
            pointsToWin.text = points + " ";
        }

        if (strengthStatValue == pointOrder[1])
        {
            points = 4;
            pointsToWin.text = points + " ";
        }

        if (strengthStatValue == pointOrder[2])
        {
            points = 3;
            pointsToWin.text = points + " ";
        }

        if (strengthStatValue == pointOrder[3])
        {
            points = 2;
            pointsToWin.text = points + " ";
        }

        if (strengthStatValue == pointOrder[4])
        {
            points = 1;
            pointsToWin.text = points + " ";
        }
    }

    public void Wingspan()
    {
        statText.text = " " + wingspanStatValue;

        go.GetComponent<Image>().enabled = true;

        if (wingspanStatValue == pointOrder[0])
        {
            points = 5;
            pointsToWin.text = points + " ";
        }

        if (wingspanStatValue == pointOrder[1])
        {
            points = 4;
            pointsToWin.text = points + " ";
        }

        if (wingspanStatValue == pointOrder[2])
        {
            points = 3;
            pointsToWin.text = points + " ";
        }

        if (wingspanStatValue == pointOrder[3])
        {
            points = 2;
            pointsToWin.text = points + " ";
        }

        if (wingspanStatValue == pointOrder[4])
        {
            points = 1;
            pointsToWin.text = points + " ";
        }
    }
}
