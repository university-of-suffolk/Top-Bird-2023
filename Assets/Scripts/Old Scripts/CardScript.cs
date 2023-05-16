//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// Card Script: Defines its attributes and values for each category. Each card should have a unique ID and be assigned to a category.

//public class Card : MonoBehaviour
//{
//    // Card attributes
//    public int cardID;
//    public string cardName;
//    public int uncommonValue;
//    public int rareValue;
//    public int epicValue;
//    public int legendaryValue;
//    public int rainbowValue;

//    // Category enum
//    public enum Category
//    {
//        Uncommon,
//        Rare,
//        Epic,
//        Legendary,
//        Rainbow
//    }

//    public Category category;

//    // Get value by category
//    public int GetValue(Category category)
//    {
//        switch (category)
//        {
//            case Category.Uncommon:
//                return uncommonValue;
//            case Category.Rare:
//                return rareValue;
//            case Category.Epic:
//                return epicValue;
//            case Category.Legendary:
//                return legendaryValue;
//            case Category.Rainbow:
//                return rainbowValue;
//            default:
//                Debug.LogError("Invalid category!");
//                return 0;
//        }
//    }
//}
