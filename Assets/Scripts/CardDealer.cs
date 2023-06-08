using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardDealer : MonoBehaviour
{    
    public GameObject playerPanel;
    public GameObject aiPanel;
    public GameObject randomCard;
    public List<GameObject> cardPrefabs; // List of card prefabs
    public GameObject aiTurnIndicator; // Reference to the AI turn indicator UI object    
    GameObject go;

    private bool playerGoesFirst = true; // Flag to determine if the player goes first or not
    public bool cardEnlarger;
    bool compare = false;
    public Text statNameText;
    public Text aiPointsToWin;

    public int randomIndex;
    public int statValue;

    public int points;
    public int[] pointOrder;
    int speedStatValue;
    int sizeStatValue;
    int weightStatValue;
    int strengthStatValue;
    int wingspanStatValue;

    private void Start()
    {
        go = GameObject.Find("Go");

        DealCards();

        if (!playerGoesFirst)
        {
            StartCoroutine(AITurnCoroutine());
        }               
    }   

    public void Compare()
    {
        if (go.GetComponent<Image>().enabled)
        {
            compare = true;
        }
        else
        {
            compare = false;
        }
    }

    private void DealCards()
    {
        int numCards = cardPrefabs.Count;
        int numCardsPerPlayer = numCards / 2; // Divide the cards equally between players

        // Shuffle the cards
        Shuffle(cardPrefabs);

        // Deal cards to the player
        for (int i = 0; i < numCardsPerPlayer; i++)
        {
            GameObject cardPrefab = cardPrefabs[i];
            InstantiateCard(cardPrefab, playerPanel.transform);
        }

        // Deal cards to the AI
        bool aiHasCard32 = false; // Flag to track if the AI has Card32
        for (int i = numCardsPerPlayer; i < numCards; i++)
        {
            GameObject cardPrefab = cardPrefabs[i];
            InstantiateCard(cardPrefab, aiPanel.transform);

            // Check if the AI has Card32
            if (cardPrefab.name == "Card32")
            {
                aiHasCard32 = true;
            }
        }
        StartCoroutine(AITurnCoroutine());
        // Start the AI turn if it has Card32
        if (aiHasCard32)
        {
            
        }
    }




    private void InstantiateCard(GameObject cardPrefab, Transform parent)
    {
        GameObject cardObject = Instantiate(cardPrefab, parent);
        CardUI cardUI = cardObject.GetComponent<CardUI>();
        if (cardUI != null)
        {
            cardUI.ScaleDown(1.00f); // Scale down the card UI

            if (parent == aiPanel.transform)
            {
                GameObject cardCover = cardObject.transform.Find("CardCover").gameObject;
                cardCover.SetActive(true); // Enable the CardCover GameObject
            }
        }
    }



    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public IEnumerator AITurnCoroutine()
{
    aiTurnIndicator.SetActive(true); // Show AI turn indicator

    yield return new WaitForSeconds(1f); // Delay to simulate AI thinking

    // Print the number of cards in the AI's panel
    Debug.Log("AI Panel Count: " + aiPanel.transform.childCount);

    // Select a random card from the AI's panel
    int numCards = aiPanel.transform.childCount;
    randomIndex = Random.Range(0, numCards);
    randomCard = aiPanel.transform.GetChild(randomIndex).gameObject;


    // Move the card to the left middle of the screen
    StartCoroutine(MoveCardToPosition(randomCard.transform, new Vector3(-4f, 0f, 0f), 1f));

    aiTurnIndicator.SetActive(false); // Hide AI turn indicator

    // Select a random stat from the card
    int numStats = randomCard.transform.Find("Stats").childCount;
    int randomStatIndex = Random.Range(0, numStats);
    Transform stat = randomCard.transform.Find("Stats").GetChild(randomStatIndex);
    Text statText = stat.GetComponent<Text>(); // Get the Text component
    statValue = int.Parse(statText.text);
    string statName = statText.name.Replace("Text", "").Replace("Stat", ""); // Remove "Text" and "Stat" from the name

    Debug.Log("AI selected Card: " + randomCard.name + " Stat: " + statName + " Value: " + statValue);

        Transform speedStat = randomCard.transform.Find("Stats").transform.Find("SpeedStatText");
        Text speedStatText = speedStat.GetComponent<Text>(); // Get the Text component
        speedStatValue = int.Parse(speedStatText.text);

        Transform sizeStat = randomCard.transform.Find("Stats").transform.Find("SizeStatText");
        Text sizeStatText = sizeStat.GetComponent<Text>(); // Get the Text component
        sizeStatValue = int.Parse(sizeStatText.text);

        Transform weightStat = randomCard.transform.Find("Stats").transform.Find("WeightStatText");
        Text weightStatText = weightStat.GetComponent<Text>(); // Get the Text component
        weightStatValue = int.Parse(weightStatText.text);

        Transform strengthStat = randomCard.transform.Find("Stats").transform.Find("StrengthStatText");
        Text strengthStatText = strengthStat.GetComponent<Text>(); // Get the Text component
        strengthStatValue = int.Parse(strengthStatText.text);

        Transform wingspanStat = randomCard.transform.Find("Stats").transform.Find("WingspanStatText");
        Text wingspanStatText = wingspanStat.GetComponent<Text>(); // Get the Text component
        wingspanStatValue = int.Parse(wingspanStatText.text);

        pointOrder = new int[] { speedStatValue, sizeStatValue, weightStatValue, strengthStatValue, wingspanStatValue };

        Array.Sort(pointOrder);

        if(statValue == pointOrder[0])
        {
            points = 5;
        }
        if (statValue == pointOrder[1])
        {
            points = 4;
        }
        if (statValue == pointOrder[2])
        {
            points = 3;
        }
        if (statValue == pointOrder[3])
        {
            points = 2;
        }
        if (statValue == pointOrder[4])
        {
            points = 1;
        }

        StopCoroutine(AITurnCoroutine());

        // TODO: Implement the logic to compare the selected card with the player's card and determine the winner

        // TODO: Implement the logic to switch turns between the player and the AI

        // EndGame();
    }

    private IEnumerator MoveCardToPosition(Transform cardTransform, Vector3 targetPosition, float moveDuration)
    {
        // Store the initial and target scales of the card
        Vector3 initialScale = cardTransform.localScale;
        Vector3 targetScale = initialScale * 1.25f;

        // Move the card to the target position while increasing its size
        float elapsedTime = 0f;
        Vector3 startPosition = cardTransform.position;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            cardTransform.position = Vector3.Lerp(startPosition, targetPosition, t);
            cardTransform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        // Set the scale of the card to the final target scale
        cardTransform.localScale = targetScale;
    }

    //=================================================
    //PARTICLES SECTION (SPERATE SCRIPT WASN'T WORKING)
    //=================================================

    public GameObject borderParticles;
    public GameObject UncommonParticle;
    public GameObject RareParticle;
    public GameObject EpicParticle;
    public GameObject LegendaryParticle;
    public GameObject RainbowParticle;
    public Material particleMaterial;


    public void Update()
    {        
        // Disable the CardCover game object
        GameObject cardCover = randomCard.transform.Find("CardCover").gameObject;
        if (compare)
        {
            cardCover.SetActive(false);

            // Update the UI Text with the selected stat name
            statNameText.text = " " + statValue;

            aiPointsToWin.text = points + " ";
        }


        if (randomCard.name == "Card1(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card2(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card3(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card4(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card5(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card6(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card7(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card8(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card9(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card10(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card11(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card12(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card13(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card14(Clone)")
        {
            Common();
        }
        if (randomCard.name == "Card15(Clone)")
        {
            Common();
        }

        if (randomCard.name == "Card16(Clone)")
        {
            Uncommon();
        }
        if (randomCard.name == "Card17(Clone)")
        {
            Uncommon();
        }
        if (randomCard.name == "Card18(Clone)")
        {
            Uncommon();
        }
        if (randomCard.name == "Card19(Clone)")
        {
            Uncommon();
        }
        if (randomCard.name == "Card20(Clone)")
        {
            Uncommon();
        }
        if (randomCard.name == "Card21(Clone)")
        {
            Uncommon();
        }
        if (randomCard.name == "Card22(Clone)")
        {
            Uncommon();
        }
        if (randomCard.name == "Card23(Clone)")
        {
            Uncommon();
        }


        if (randomCard.name == "Card24(Clone)")
        {
            Rare();
        }
        if (randomCard.name == "Card25(Clone)")
        {
            Rare();
        }
        if (randomCard.name == "Card26(Clone)")
        {
            Rare();
        }
        if (randomCard.name == "Card27(Clone)")
        {
            Rare();
        }

        if (randomCard.name == "Card28(Clone)")
        {
            Epic();
        }
        if (randomCard.name == "Card29(Clone)")
        {
            Epic();
        }

        if (randomCard.name == "Card30(Clone)")
        {
            Legendary();
        }
        if (randomCard.name == "Card31(Clone)")
        {
            Legendary();
        }

        if (randomCard.name == "Card32(Clone)")
        {
            Rainbow();
        }
    }


    public void Common()
    {

        borderParticles.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.black;

    }

    public void Uncommon()
    {
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(true);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.gray;
    }

    public void Rare()
    {
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(true);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.red;
    }

    public void Epic()
    {
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(true);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.green;
    }

    public void Legendary()
    {
        borderParticles.SetActive(true);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(true);
        RainbowParticle.SetActive(false);
        particleMaterial.color = Color.yellow;

    }

    public void Rainbow()
    {
        borderParticles.SetActive(false);
        UncommonParticle.SetActive(false);
        RareParticle.SetActive(false);
        EpicParticle.SetActive(false);
        LegendaryParticle.SetActive(false);
        RainbowParticle.SetActive(true);
    }



}
