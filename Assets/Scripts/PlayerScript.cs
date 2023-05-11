//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// This script will define the player's attributes, such as their score, cards they hold, and their turn order.

//public class Player : MonoBehaviour
//{
//    // Player attributes
//    public int playerID;
//    public int score;
//    public List<Card> hand = new List<Card>();

//    // Add a card to the player's hand
//    public void AddCard(Card card)
//    {
//        hand.Add(card);
//    }

//    // Remove a card from the player's hand
//    public void RemoveCard(Card card)
//    {
//        hand.Remove(card);
//    }

//    public List<Card> GetHand()
//    {
//        return hand;
//    }

//    // Get the player's score
//    public int GetScore()
//    {
//        return score;
//    }

//    // Increase the player's score
//    public void IncreaseScore()
//    {
//        score++;
//    }

//    // Add to the player's score
//    public void AddToScore(int amount = 1)
//    {
//        score += amount;
//    }

//    // Check if the player's hand is empty
//    public bool IsHandEmpty()
//    {
//        return hand.Count == 0;
//    }
//}
