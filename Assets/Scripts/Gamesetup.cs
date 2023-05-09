//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GameSetup : MonoBehaviour
//{
//    public GameObject cardPrefab;

//    void Start()
//    {
//        Create 32 Cards with their properties

//         15 Common Cards
//         8 Uncommon Cards
//         4 Rare
//         2 Epic
//         2 Legendary
//         1 Rainbow

//        List<Card> cards = new List<Card>();

//        cards.Add(new Card("Card 1", Card.Stats.Wingspan, 36,
//            Card.Stats.Speed, 23, Card.Stats.Strength, 4, Card.Stats.Weight, 70, Card.Stats.Size, 44, Card.Category.Common, 2));

//        cards.Add(new Card("Card 2", Card.Stats.Wingspan, 16,
//            Card.Stats.Speed, 16, Card.Stats.Strength, 5, Card.Stats.Weight, 70, Card.Stats.Size, 38, Card.Category.Common, 2));

//        cards.Add(new Card("Card 3", Card.Stats.Wingspan, 43,
//            Card.Stats.Speed, 12, Card.Stats.Strength, 8, Card.Stats.Weight, 47, Card.Stats.Size, 48, Card.Category.Common, 2));

//        cards.Add(new Card("Card 4", Card.Stats.Wingspan, 42,
//            Card.Stats.Speed, 7, Card.Stats.Strength, 7, Card.Stats.Weight, 42, Card.Stats.Size, 28, Card.Category.Common, 2));

//        cards.Add(new Card("Card 5", Card.Stats.Wingspan, 44,
//            Card.Stats.Speed, 17, Card.Stats.Strength, 5, Card.Stats.Weight, 53, Card.Stats.Size, 50, Card.Category.Common, 2));

//        cards.Add(new Card("Card 6", Card.Stats.Wingspan, 37,
//            Card.Stats.Speed, 14, Card.Stats.Strength, 8, Card.Stats.Weight, 64, Card.Stats.Size, 26, Card.Category.Common, 2));

//        cards.Add(new Card("Card 7", Card.Stats.Wingspan, 23,
//            Card.Stats.Speed, 12, Card.Stats.Strength, 4, Card.Stats.Weight, 72, Card.Stats.Size, 30, Card.Category.Common, 2));

//        cards.Add(new Card("Card 8", Card.Stats.Wingspan, 12,
//            Card.Stats.Speed, 20, Card.Stats.Strength, 6, Card.Stats.Weight, 47, Card.Stats.Size, 16, Card.Category.Common, 2));

//        cards.Add(new Card("Card 9", Card.Stats.Wingspan, 19,
//            Card.Stats.Speed, 9, Card.Stats.Strength, 7, Card.Stats.Weight, 45, Card.Stats.Size, 49, Card.Category.Common, 2));

//        cards.Add(new Card("Card 10", Card.Stats.Wingspan, 28,
//            Card.Stats.Speed, 10, Card.Stats.Strength, 8, Card.Stats.Weight, 58, Card.Stats.Size, 16, Card.Category.Common, 2));

//        cards.Add(new Card("Card 11", Card.Stats.Wingspan, 31,
//            Card.Stats.Speed, 11, Card.Stats.Strength, 5, Card.Stats.Weight, 69, Card.Stats.Size, 47, Card.Category.Common, 2));

//        cards.Add(new Card("Card 12", Card.Stats.Wingspan, 48,
//            Card.Stats.Speed, 13, Card.Stats.Strength, 8, Card.Stats.Weight, 51, Card.Stats.Size, 38, Card.Category.Common, 2));

//        cards.Add(new Card("Card 13", Card.Stats.Wingspan, 13,
//            Card.Stats.Speed, 6, Card.Stats.Strength, 4, Card.Stats.Weight, 73, Card.Stats.Size, 34, Card.Category.Common, 2));

//        cards.Add(new Card("Card 14", Card.Stats.Wingspan, 44,
//            Card.Stats.Speed, 25, Card.Stats.Strength, 7, Card.Stats.Weight, 63, Card.Stats.Size, 32, Card.Category.Common, 2));

//        cards.Add(new Card("Card 15", Card.Stats.Wingspan, 32,
//            Card.Stats.Speed, 8, Card.Stats.Strength, 6, Card.Stats.Weight, 53, Card.Stats.Size, 50, Card.Category.Common, 2));

//        cards.Add(new Card("Card 16", Card.Stats.Wingspan, 33,
//            Card.Stats.Speed, 34, Card.Stats.Strength, 6, Card.Stats.Weight, 106, Card.Stats.Size, 53, Card.Category.Uncommon, 3));

//        cards.Add(new Card("Card 17", Card.Stats.Wingspan, 59,
//            Card.Stats.Speed, 30, Card.Stats.Strength, 10, Card.Stats.Weight, 107, Card.Stats.Size, 51, Card.Category.Uncommon, 3));

//        cards.Add(new Card("Card 18", Card.Stats.Wingspan, 38,
//            Card.Stats.Speed, 26, Card.Stats.Strength, 7, Card.Stats.Weight, 100, Card.Stats.Size, 55, Card.Category.Uncommon, 3));

//        cards.Add(new Card("Card 19", Card.Stats.Wingspan, 32,
//            Card.Stats.Speed, 27, Card.Stats.Strength, 8, Card.Stats.Weight, 107, Card.Stats.Size, 52, Card.Category.Uncommon, 3));

//        cards.Add(new Card("Card 20", Card.Stats.Wingspan, 66,
//            Card.Stats.Speed, 23, Card.Stats.Strength, 7, Card.Stats.Weight, 77, Card.Stats.Size, 37, Card.Category.Uncommon, 3));

//        cards.Add(new Card("Card 21", Card.Stats.Wingspan, 37,
//            Card.Stats.Speed, 30, Card.Stats.Strength, 8, Card.Stats.Weight, 88, Card.Stats.Size, 53, Card.Category.Uncommon, 3));

//        cards.Add(new Card("Card 22", Card.Stats.Wingspan, 36,
//            Card.Stats.Speed, 33, Card.Stats.Strength, 6, Card.Stats.Weight, 75, Card.Stats.Size, 42, Card.Category.Uncommon, 3));

//        cards.Add(new Card("Card 23", Card.Stats.Wingspan, 69,
//            Card.Stats.Speed, 20, Card.Stats.Strength, 8, Card.Stats.Weight, 92, Card.Stats.Size, 60, Card.Category.Uncommon, 3));

//        cards.Add(new Card("Card 24", Card.Stats.Wingspan, 64,
//            Card.Stats.Speed, 34, Card.Stats.Strength, 8, Card.Stats.Weight, 93, Card.Stats.Size, 57, Card.Category.Rare, 4));

//        cards.Add(new Card("Card 25", Card.Stats.Wingspan, 76,
//            Card.Stats.Speed, 41, Card.Stats.Strength, 10, Card.Stats.Weight, 114, Card.Stats.Size, 86, Card.Category.Rare, 4));

//        cards.Add(new Card("Card 26", Card.Stats.Wingspan, 58,
//            Card.Stats.Speed, 34, Card.Stats.Strength, 11, Card.Stats.Weight, 112, Card.Stats.Size, 60, Card.Category.Rare, 4));

//        cards.Add(new Card("Card 27", Card.Stats.Wingspan, 84,
//            Card.Stats.Speed, 35, Card.Stats.Strength, 12, Card.Stats.Weight, 113, Card.Stats.Size, 69, Card.Category.Rare, 4));

//        cards.Add(new Card("Card 28", Card.Stats.Wingspan, 85,
//            Card.Stats.Speed, 51, Card.Stats.Strength, 15, Card.Stats.Weight, 141, Card.Stats.Size, 78, Card.Category.Epic, 5));

//        cards.Add(new Card("Card 29", Card.Stats.Wingspan, 97,
//            Card.Stats.Speed, 37, Card.Stats.Strength, 13, Card.Stats.Weight, 102, Card.Stats.Size, 81, Card.Category.Epic, 5));

//        cards.Add(new Card("Card 30", Card.Stats.Wingspan, 99,
//            Card.Stats.Speed, 62, Card.Stats.Strength, 17, Card.Stats.Weight, 170, Card.Stats.Size, 108, Card.Category.Legendary, 6));

//        cards.Add(new Card("Card 31", Card.Stats.Wingspan, 128,
//            Card.Stats.Speed, 53, Card.Stats.Strength, 16, Card.Stats.Weight, 174, Card.Stats.Size, 110, Card.Category.Legendary, 6));

//        cards.Add(new Card("Card 32", Card.Stats.Wingspan, 140,
//            Card.Stats.Speed, 70, Card.Stats.Strength, 20, Card.Stats.Weight, 180, Card.Stats.Size, 145, Card.Category.Rainbow, 7));

//        Create a new game object for each card and set its properties
//        for (int i = 0; i < cards.Count; i++)
//            {

//            }
//    }
//}