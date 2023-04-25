using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script will define the AI's behavior and how they will choose which category to compare against the player's card. 

public class AI : MonoBehaviour
{
    public int difficultyLevel; // Determines the difficulty of the AI, with higher levels making the AI smarter
    public int selectedCategory; // The index of the selected category

    private Player player;
    private List<Card> hand;

    void Awake()
    {
        player = GetComponent<Player>();
        hand = player.GetHand();
    }

    public int ChooseCategory()
    {
        int maxVal = -1;
        int maxIndex = -1;
        for (int i = 0; i < hand.Count; i++)
        {
            int val = 0;
            switch (selectedCategory)
            {
                case 0:
                    val = hand[i].uncommonValue;
                    break;
                case 1:
                    val = hand[i].rareValue;
                    break;
                case 2:
                    val = hand[i].epicValue;
                    break;
                case 3:
                    val = hand[i].legendaryValue;
                    break;
                case 4:
                    val = hand[i].rainbowValue;
                    break;
            }
            if (val > maxVal)
            {
                maxVal = val;
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    public void SelectCategory()
    {
        if (difficultyLevel == 1) // Easy difficulty just selects a random category
        {
            selectedCategory = Random.Range(0, 5);
        }
        else // Hard difficulty selects the category with the highest average value
        {
            float[] avgValues = new float[5];
            for (int i = 0; i < hand.Count; i++)
            {
                avgValues[0] += hand[i].uncommonValue;
                avgValues[1] += hand[i].rareValue;
                avgValues[2] += hand[i].epicValue;
                avgValues[3] += hand[i].legendaryValue;
                avgValues[4] += hand[i].rainbowValue;
            }
            for (int i = 0; i < 5; i++)
            {
                avgValues[i] /= hand.Count;
            }
            float maxAvg = -1f;
            int maxIndex = -1;
            for (int i = 0; i < 5; i++)
            {
                if (avgValues[i] > maxAvg)
                {
                    maxAvg = avgValues[i];
                    maxIndex = i;
                }
            }
            selectedCategory = maxIndex;
        }
    }
}
