using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{

    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "Fizzletwit", 36, 23, 4, 70, 44));
        cardList.Add(new Card(1, "Quirkyquawk", 16, 16, 5, 70, 38));
        cardList.Add(new Card(2, "Squawkadoodle", 43, 12, 8, 47, 48));
        cardList.Add(new Card(3, "Flutterflap", 42, 7, 7, 42, 28));
        cardList.Add(new Card(4, "Tweedlebeak", 44, 17, 5, 53, 50));
        cardList.Add(new Card(5, "Chirpington", 37, 14, 8, 64, 26));
        cardList.Add(new Card(6, "Zippertweet", 23, 12, 4, 72, 30));
        cardList.Add(new Card(7, "Peckleplum", 12, 20, 6, 47, 16));
        cardList.Add(new Card(8, "Wingdingo", 19, 9, 7, 45, 49));
        cardList.Add(new Card(9, "Beaklebob", 28, 10, 8, 58, 16));
        cardList.Add(new Card(10, "Puffernoodle", 31, 11, 5, 69, 47));
        cardList.Add(new Card(11, "Squigglewings", 48, 13, 8, 51, 38));
        cardList.Add(new Card(12, "Flapjazz", 13, 6, 4, 73, 34));
        cardList.Add(new Card(13, "Snickerdoodlebird", 44, 25, 7, 63, 32));
        cardList.Add(new Card(14, "Twirlfeather", 32, 8, 6, 53, 50));
        cardList.Add(new Card(15, "Blinkerbeak", 33, 34, 6, 106, 53));
        cardList.Add(new Card(16, "Doodleduck", 59, 30, 10, 107, 51));
        cardList.Add(new Card(17, "Ticklebeak", 38, 26, 7, 100, 55));
        cardList.Add(new Card(18, "Noodlenest", 32, 27, 8, 107, 52));
        cardList.Add(new Card(19, "Wiggletail", 66, 23, 7, 77, 37));
        cardList.Add(new Card(20, "Hootenanny", 37, 30, 8, 88, 53));
        cardList.Add(new Card(21, "Swirlybird", 36, 33, 6, 75, 42));
        cardList.Add(new Card(22, "Bouncearoo", 69, 20, 8, 92, 60));
        cardList.Add(new Card(23, "Skedaddlewaddle", 64, 34, 8, 93, 57));
        cardList.Add(new Card(24, "Chucklecluck", 76, 41, 10, 114, 86));
        cardList.Add(new Card(25, "Razzlefeather", 58, 34, 11, 112, 60));
        cardList.Add(new Card(26, "Gigglebeak", 84, 35, 12, 113, 69));
        cardList.Add(new Card(27, "Whirlywing", 85, 51, 15, 141, 78));
        cardList.Add(new Card(28, "Jigglejay", 97, 37, 13, 102, 81));
        cardList.Add(new Card(29, "Fiddletail", 99, 62, 17, 170, 108));
        cardList.Add(new Card(30, "Hopscotchick", 128, 53, 16, 174, 110));
        cardList.Add(new Card(31, "Wrigglebeak", 140, 70, 20, 180, 145));
    }

}
