//using UnityEngine;

//public class CardManager : MonoBehaviour
//{
//    public GameObject cardTemplate;
//    public int numCards = 5;

//    private Transform cardContainer;

//    void Start()
//    {
//        cardContainer = GameObject.Find("CardTemplate").transform;
//        SpawnCards();
//    }

//    void SpawnCards()
//    {
//        for (int i = 0; i < numCards; i++)
//        {
//            GameObject clonedCard = Instantiate(cardTemplate, cardContainer);
//            clonedCard.SetActive(true);

//            CardPrefabController cardPrefabController = clonedCard.GetComponent<CardPrefabController>();
//            cardPrefabController.SetCardIndex(i);
//        }
//    }
//}
