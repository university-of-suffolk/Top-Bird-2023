//using System;
//using System.Collections.Generic;

//public class Card
//{
//    public string Category { get; set; }
//    public int Stat1 { get; set; }
//    public int Stat2 { get; set; }
//    public int Stat3 { get; set; }
//    public int Stat4 { get; set; }
//    public int Stat5 { get; set; }

//    public Card(string category)
//    {
//        Category = category;
//        Random random = new Random();
//        switch (category)
//        {
//            case "Common":
//                Stat1 = random.Next(10, 50);
//                Stat2 = random.Next(5, 25);
//                Stat3 = random.Next(40, 80);
//                Stat4 = random.Next(15, 55);
//                Stat5 = random.Next(4, 8);
//                break;
//            case "Uncommon":
//                Stat1 = random.Next(30, 70);
//                Stat2 = random.Next(15, 35);
//                Stat3 = random.Next(70, 110);
//                Stat4 = random.Next(35, 75);
//                Stat5 = random.Next(6, 10);
//                break;
//            case "Rare":
//                Stat1 = random.Next(50, 90);
//                Stat2 = random.Next(25, 45);
//                Stat3 = random.Next(80, 120);
//                Stat4 = random.Next(55, 95);
//                Stat5 = random.Next(8, 14);
//                break;
//            case "Epic":
//                Stat1 = random.Next(90, 130);
//                Stat2 = random.Next(45, 65);
//                Stat3 = random.Next(120, 170);
//                Stat4 = random.Next(95, 130);
//                Stat5 = random.Next(12, 18);
//                break;
//            case "Legendary":
//                Stat1 = random.Next(130, 170);
//                Stat2 = random.Next(65, 85);
//                Stat3 = random.Next(170, 220);
//                Stat4 = random.Next(130, 165);
//                Stat5 = random.Next(16, 22);
//                break;
//            case "Rainbow":
//                Stat1 = 140;
//                Stat2 = 70;
//                Stat3 = 180;
//                Stat4 = 145;
//                Stat5 = 20;
//                break;
//            default:
//                throw new ArgumentException("Invalid category");
//        }
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        List<string> categories = new List<string> { "Common", "Uncommon", "Rare", "Epic", "Legendary", "Rainbow" };
//        List<Card> cards = new List<Card>();

//        foreach (string category in categories)
//        {
//            for (int i = 0; i < 30; i++) // Generate 30 cards for Common Category
//            {
//                cards.Add(new CardCommon(category));
//            }

//            for (int i = 0; i < 18; i++) // Generate 18 cards for Uncommon Category
//            {
//                cards.Add(new CardUncommon(category));
//            }

//            for (int i = 0; i < 9; i++) // Generate 9 cards for Rare Category
//            {
//                cards.Add(new CardRare(category));
//            }

//            for (int i = 0; i < 4; i++) // Generate 4 cards for Epic Category
//            {
//                cards.Add(new CardEpic(category));
//            }

//            for (int i = 0; i < 2; i++) // Generate 2 cards for Legendary Category
//            {
//                cards.Add(new CardLegendary(category));
//            }

//            for (int i = 0; i < 1; i++) // Generate 1 card for Rainbow Category
//            {
//                cards.Add(new CardRainbow(category));
//            }
//        }

//        foreach (Card card in cards)
//        {
//            Console.WriteLine($"Category: {card.Category}, Stat1: {card.Stat1}, Stat2: {card.Stat2}, Stat3: {card.Stat3}, Stat4: {card.Stat4}, Stat5: {card.Stat5}");
//        }
//    }
//}