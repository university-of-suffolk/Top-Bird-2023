using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPoints : MonoBehaviour
{
    public int points;
    public int[] pointOrder;
    int speedStatValue;
    int sizeStatValue;
    int weightStatValue;
    int strengthStatValue;
    int wingspanStatValue;

    public Text playerPoints;

    private void Start()
    {
        Transform speedStat = gameObject.transform.Find("SpeedButton").transform.Find("SpeedStatText");
        Text speedStatText = speedStat.GetComponent<Text>(); // Get the Text component
        speedStatValue = int.Parse(speedStatText.text);

        Transform sizeStat = gameObject.transform.Find("SizeButton").transform.Find("SizeStatText");
        Text sizeStatText = sizeStat.GetComponent<Text>(); // Get the Text component
        sizeStatValue = int.Parse(sizeStatText.text);

        Transform weightStat = gameObject.transform.Find("WeightButton").transform.Find("WeightStatText");
        Text weightStatText = weightStat.GetComponent<Text>(); // Get the Text component
        weightStatValue = int.Parse(weightStatText.text);

        Transform strengthStat = gameObject.transform.Find("StrengthButton").transform.Find("StrengthStatText");
        Text strengthStatText = strengthStat.GetComponent<Text>(); // Get the Text component
        strengthStatValue = int.Parse(strengthStatText.text);

        Transform wingspanStat = gameObject.transform.Find("WingspanButton").transform.Find("WingspanStatText");
        Text wingspanStatText = wingspanStat.GetComponent<Text>(); // Get the Text component
        wingspanStatValue = int.Parse(wingspanStatText.text);

        pointOrder = new int[] { speedStatValue, sizeStatValue, weightStatValue, strengthStatValue, wingspanStatValue };

        Array.Sort(pointOrder);
              
    }

    public void Speed()
    {
        
        if (speedStatValue == pointOrder[0])
        {
            points += 5;
            playerPoints.GetComponent<Text>().text = points + " ";            
        }

        if (speedStatValue == pointOrder[1])
        {
            points += 4;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (speedStatValue == pointOrder[2])
        {
            points += 3;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (speedStatValue == pointOrder[3])
        {
            points += 2;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (speedStatValue == pointOrder[4])
        {
            points += 1;
            playerPoints.GetComponent<Text>().text = points + " ";
        }
    }

    public void Size()
    {
        if (sizeStatValue == pointOrder[0])
        {
            points += 5;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (sizeStatValue == pointOrder[1])
        {
            points += 4;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (sizeStatValue == pointOrder[2])
        {
            points += 3;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (sizeStatValue == pointOrder[3])
        {
            points += 2;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (sizeStatValue == pointOrder[4])
        {
            points += 1;
            playerPoints.GetComponent<Text>().text = points + " ";
        }
    }

    public void Weight()
    {
        if (weightStatValue == pointOrder[0])
        {
            points += 5;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (weightStatValue == pointOrder[1])
        {
            points += 4;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (weightStatValue == pointOrder[2])
        {
            points += 3;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (weightStatValue == pointOrder[3])
        {
            points += 2;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (weightStatValue == pointOrder[4])
        {
            points += 1;
            playerPoints.GetComponent<Text>().text = points + " ";
        }
    }

    public void Strength()
    {
        if (strengthStatValue == pointOrder[0])
        {
            points += 5;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (strengthStatValue == pointOrder[1])
        {
            points += 4;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (strengthStatValue == pointOrder[2])
        {
            points += 3;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (strengthStatValue == pointOrder[3])
        {
            points += 2;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (strengthStatValue == pointOrder[4])
        {
            points += 1;
            playerPoints.GetComponent<Text>().text = points + " ";
        }
    }

    public void Wingspan()
    {
        if (wingspanStatValue == pointOrder[0])
        {
            points += 5;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (wingspanStatValue == pointOrder[1])
        {
            points += 4;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (wingspanStatValue == pointOrder[2])
        {
            points += 3;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (wingspanStatValue == pointOrder[3])
        {
            points += 2;
            playerPoints.GetComponent<Text>().text = points + " ";
        }

        if (wingspanStatValue == pointOrder[4])
        {
            points += 1;
            playerPoints.GetComponent<Text>().text = points + " ";
        }
    }
}
