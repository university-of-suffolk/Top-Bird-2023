//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//// This script will manage the game's logic and flow, such as checking which category the players will compare and determining the winner of each round.

//public enum Category : int
//{
//    Uncommon = Card.Category.Uncommon,
//    Rare = Card.Category.Rare,
//    Epic = Card.Category.Epic,
//    Legendary = Card.Category.Legendary,
//    Rainbow = Card.Category.Rainbow
//}



//public class GameManager : MonoBehaviour
//{
//    // Player prefabs to instantiate
//    public GameObject player1Prefab;
//    public GameObject player2Prefab;

//    // Reference to the deck object
//    public Deck deck;

//    // Reference to the UI elements
//    public Text player1ScoreText;
//    public Text player2ScoreText;
//    public Text resultText;
//    public Text highScoreText;

//    public Slider player1ScoreSlider;
//    public Slider player2ScoreSlider;

//    // Game state variables
//    private Player player1;
//    private Player player2;
//    private int currentPlayer;
//    private static int highScore;
//    private Card currentCard;

//    // Start the game
//    void Start()
//    {
//        highScore = PlayerPrefs.SetInt ("HighScore", highScore);

//        // Instantiate the players
//        player1 = Instantiate(player1Prefab, transform).GetComponent<Player>();
//        player1.playerID = 1;
//        player2 = Instantiate(player2Prefab, transform).GetComponent<Player>();
//        player2.playerID = 2;

//        // Initialize the deck
//        deck.InitializeDeck(20);
//        deck.ShuffleDeck();

//        // Deal cards to the players
//        while (!deck.IsEmpty())
//        {
//            player1.AddCard(deck.DealCard());
//            player2.AddCard(deck.DealCard());
//        }

//        // Start the game
//        currentPlayer = Random.Range(1, 3);
//        StartTurn();
//    }

//    // Start a new turn
//    private void StartTurn()
//    {
//        // Get a card from the current player's hand
//        currentCard = GetNextCard();
//        UpdateUI();

//        // If the current player's hand is empty, end the game
//        if (currentPlayer == 1 && player1.IsHandEmpty() || currentPlayer == 2 && player2.IsHandEmpty())
//        {
//            EndGame();
//        }
//        else
//        {
//            // Show the current player's turn in the UI
//            resultText.text = "Player " + currentPlayer + "'s turn.";
//        }
//    }

//    // Get the next card from the current player's hand
//    private Card GetNextCard()
//    {
//        Card nextCard;
//        if (currentPlayer == 1)
//        {
//            nextCard = player1.hand[0];
//            player1.RemoveCard(nextCard);
//        }
//        else
//        {
//            nextCard = player2.hand[0];
//            player2.RemoveCard(nextCard);
//        }
//        return nextCard;
//    }

//    public void CompareCards()
//    {
//        int player1Score = player1.GetScore();
//        int player2Score = player2.GetScore();
//        player1ScoreSlider.Value += player1.GetScore();
//        player2ScoreSlider.Value += player2.GetScore();

//        int value1 = 0;
//        int value2 = 0;

//        // Determine which value to compare based on the current card's category
//        switch (currentCard.category)
//        {
//            case Card.Category.Uncommon:
//                value1 = currentCard.uncommonValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Uncommon);
//                break;
//            case Card.Category.Rare:
//                value1 = currentCard.rareValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Rare);
//                break;
//            case Card.Category.Epic:
//                value1 = currentCard.epicValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Epic);
//                break;
//            case Card.Category.Legendary:
//                value1 = currentCard.legendaryValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Legendary);
//                break;
//            case Card.Category.Rainbow:
//                value1 = currentCard.rainbowValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Rainbow);
//                break;
//        }


//        // Compare the values and update the score and UI
//        if (value1 > value2)
//        {
//            if (currentPlayer == 1)
//            {
//                player1.AddToScore(1);
//                resultText.text = "Player 1 wins!";
//            }
//            else
//            {
//                player2.AddToScore(1);
//                resultText.text = "Player 2 wins!";
//            }
//        }
//        else if (value2 > value1)
//        {
//            if (currentPlayer == 1)
//            {
//                player2.AddToScore(1);
//                resultText.text = "Player 2 wins!";
//            }
//            else
//            {
//                player1.AddToScore(1);
//                resultText.text = "Player 1 wins!";
//            }
//        }
//        else
//        {
//            resultText.text = "It's a tie!";
//        }

//        // Update the UI with the new scores
//        player1ScoreText.text = "Player 1: " + player1.GetScore();
//        player2ScoreText.text = "Player 2: " + player2.GetScore();

//        // Start the next turn
//        currentPlayer = currentPlayer == 1 ? 2 : 1;
//        StartTurn();
//    }


//    // Get a random value for the specified category from the specified hand
//    private int GetRandomValue(List<Card> hand, Card.Category category)
//    {
//        int value = 0;
//        List<Card> categoryCards = new List<Card>();
//        foreach (Card card in hand)
//        {
//            if (card.category == category)
//            {
//                categoryCards.Add(card);
//            }
//        }
//        if (categoryCards.Count > 0)
//        {
//            int randomIndex = Random.Range(0, categoryCards.Count);
//            switch (category)
//            {
//                case Card.Category.Uncommon:
//                    value = categoryCards[randomIndex].uncommonValue;
//                    break;
//                case Card.Category.Rare:
//                    value = categoryCards[randomIndex].rareValue;
//                    break;
//                case Card.Category.Epic:
//                    value = categoryCards[randomIndex].epicValue;
//                    break;
//                case Card.Category.Legendary:
//                    value = categoryCards[randomIndex].legendaryValue;
//                    break;
//                case Card.Category.Rainbow:
//                    value = categoryCards[randomIndex].rainbowValue;
//                    break;
//            }
//        }
//        return value;
//    }


//    // End the game and display the winner
//    private void EndGame()
//    {
//        if (player1.GetScore() > player2.GetScore())
//        {
//            resultText.text = "Player 1 wins the game!";
//        }
//        else if (player2.GetScore() > player1.GetScore())
//        {
//            resultText.text = "Player 2 wins the game!";
//        }
//        else
//        {
//            resultText.text = "It's a tie!";
//        }
//    }

//    private void UpdateUI()
//    {
//        int player1Score = player1.GetScore();
//        int player2Score = player2.GetScore();

//        if (currentPlayer == 1 && player1Score > highScore)
//        {
//            highScore = player1Score;
//            highScoreText.text = "HighScore" + " " + player1Score;
//        }
//        else if (currentPlayer == 2 && player2Score > highScore)
//        {
//            highScore = player2Score;
//            highScoreText.text = "HighScore" + " " + player2Score;
//        }

//        PlayerPrefs.SetInt ("HighScore", highScore);
//        PlayerPrefs.Save();

//        int value1 = 0;
//        int value2 = 0;

//        // Update the UI text elements with the current card's category and values
//        switch (currentCard.category)
//        {
//            case Card.Category.Uncommon:
//                value1 = currentCard.uncommonValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Uncommon);
//                break;
//            case Card.Category.Rare:
//                value1 = currentCard.rareValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Rare);
//                break;
//            case Card.Category.Epic:
//                value1 = currentCard.epicValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Epic);
//                break;
//            case Card.Category.Legendary:
//                value1 = currentCard.legendaryValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Legendary);
//                break;
//            case Card.Category.Rainbow:
//                value1 = currentCard.rainbowValue;
//                value2 = GetRandomValue(player2.GetHand(), Card.Category.Rainbow);
//                break;
//        }

//    }

//}

