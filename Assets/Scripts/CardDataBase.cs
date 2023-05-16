using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{

    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "TESTER", 00, 00, 00, 00, 00, Resources.Load<Sprite>("1"), "Rainbow"));
        cardList.Add(new Card(1, "FIZZLETWIT", 36, 23, 4, 70, 44, Resources.Load <Sprite>("1"), "Grey" ));
        cardList.Add(new Card(2, "QUIRKYQUAWK", 16, 16, 5, 70, 38, Resources.Load <Sprite>("2"), "Grey"));
        cardList.Add(new Card(3, "SQUAWKADOODLE", 43, 12, 8, 47, 48, Resources.Load <Sprite>("3"), "Grey"));
        cardList.Add(new Card(4, "FLUTTERFLAP", 42, 7, 7, 42, 28, Resources.Load <Sprite>("4"), "Grey"));
        cardList.Add(new Card(5, "TWEEDLEBEAK", 44, 17, 5, 53, 50, Resources.Load <Sprite>("5"), "Grey"));
        cardList.Add(new Card(6, "CHIRPINGTON", 37, 14, 8, 64, 26, Resources.Load <Sprite>("6"), "Grey"));
        cardList.Add(new Card(7, "ZIPPERTWEET", 23, 12, 4, 72, 30, Resources.Load <Sprite>("7"), "Grey"));
        cardList.Add(new Card(8, "PECKLEPLUM", 12, 20, 6, 47, 16, Resources.Load <Sprite>("8"), "Grey"));
        cardList.Add(new Card(9, "WINGDINGO", 19, 9, 7, 45, 49, Resources.Load <Sprite>("9"), "Grey"));
        cardList.Add(new Card(10, "BEAKLEBOB", 28, 10, 8, 58, 16, Resources.Load <Sprite>("10"), "Grey"));
        cardList.Add(new Card(11, "PUFFERNOODLE", 31, 11, 5, 69, 47, Resources.Load <Sprite>("11"), "Grey"));
        cardList.Add(new Card(12, "SQUIGGLEWINGS", 48, 13, 8, 51, 38, Resources.Load <Sprite>("12"), "Grey"));
        cardList.Add(new Card(13, "FLAPJAZZ", 13, 6, 4, 73, 34, Resources.Load <Sprite>("13"), "Grey"));
        cardList.Add(new Card(14, "SNICKERDOODLE", 44, 25, 7, 63, 32, Resources.Load <Sprite>("14"), "Grey"));
        cardList.Add(new Card(15, "TWIRLFEATHER", 32, 8, 6, 53, 50, Resources.Load <Sprite>("15"), "Grey"));
        cardList.Add(new Card(16, "BLINKERBEAK", 33, 34, 6, 106, 53, Resources.Load <Sprite>("16"), "Blue"));
        cardList.Add(new Card(17, "DOODLEDUCK", 59, 30, 10, 107, 51, Resources.Load <Sprite>("17"), "Blue"));
        cardList.Add(new Card(18, "TICKLEBEAK", 38, 26, 7, 100, 55, Resources.Load <Sprite>("18"), "Blue"));
        cardList.Add(new Card(19, "NOODLENEST", 32, 27, 8, 107, 52, Resources.Load <Sprite>("19"), "Blue"));
        cardList.Add(new Card(20, "WIGGLETAIL", 66, 23, 7, 77, 37, Resources.Load <Sprite>("20"), "Blue"));
        cardList.Add(new Card(21, "HOOTENANNY", 37, 30, 8, 88, 53, Resources.Load <Sprite>("21"), "Blue"));
        cardList.Add(new Card(22, "SWIRLYBIRD", 36, 33, 6, 75, 42, Resources.Load <Sprite>("22"), "Blue"));
        cardList.Add(new Card(23, "BOUNCEAROO", 69, 20, 8, 92, 60, Resources.Load <Sprite>("23"), "Blue"));
        cardList.Add(new Card(24, "SKEDADDLEWADDLE", 64, 34, 8, 93, 57, Resources.Load <Sprite>("24"), "Red"));
        cardList.Add(new Card(25, "CHUCKLECLUCK", 76, 41, 10, 114, 86, Resources.Load <Sprite>("25"), "Red"));
        cardList.Add(new Card(26, "RAZZLEFEATHER", 58, 34, 11, 112, 60, Resources.Load <Sprite>("26"), "Red"));
        cardList.Add(new Card(27, "GIGGLEBEAK", 84, 35, 12, 113, 69, Resources.Load <Sprite>("27"), "Red"));
        cardList.Add(new Card(28, "WHIRLYWING", 85, 51, 15, 141, 78, Resources.Load <Sprite>("28"), "Green"));
        cardList.Add(new Card(29, "JIGGLEJAY", 97, 37, 13, 102, 81, Resources.Load <Sprite>("29"), "Green"));
        cardList.Add(new Card(30, "FIDDLETAIL", 99, 62, 17, 170, 108, Resources.Load <Sprite>("30"), "Gold"));
        cardList.Add(new Card(31, "HOPSCOTCHICK", 128, 53, 16, 174, 110, Resources.Load <Sprite>("31"), "Gold"));
        cardList.Add(new Card(32, "WRIGGLEBEAK", 140, 70, 20, 180, 145, Resources.Load <Sprite>("32"), "Rainbow"));
    }

}
