using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text statNameText;
    private GameObject playerCard;
    private GameObject aiCard;
    private Vector3 selectedCardPosition = new Vector3(-5f, 0f, 0f); // Adjust the position as needed


    public void StartPlayerTurn(GameObject card)
    {
        playerCard = card;
        string selectedStat = GetSelectedStat(playerCard);
        statNameText.text = selectedStat;
    }


    public void StartAITurn(GameObject aiPanel)
{
    // Randomly select a card from the AI's panel
    int aiCardIndex = Random.Range(0, aiPanel.transform.childCount);
    aiCard = aiPanel.transform.GetChild(aiCardIndex).gameObject;

    // Randomly select a stat from the selected AI card
    int statIndex = Random.Range(0, aiCard.transform.Find("Stats").childCount);
    GameObject statObject = aiCard.transform.Find("Stats").GetChild(statIndex).gameObject;

    // Print the selected stat name to the console
    string selectedStat = statObject.name.Replace("StatText", "");
    Debug.Log("AI selected stat: " + selectedStat);

    // Update the statNameText with the selected category name
    statNameText.text = selectedStat;

    // Get the RectTransform component of the card
    RectTransform cardRectTransform = aiCard.GetComponent<RectTransform>();

    // Get the RectTransform component of the canvas
    RectTransform canvasRectTransform = FindObjectOfType<Canvas>().GetComponent<RectTransform>();

    // Set the card's parent to the canvas
    cardRectTransform.SetParent(canvasRectTransform);

    // Set the anchor and pivot of the card to the middle left
    cardRectTransform.anchorMin = new Vector2(0, 0.5f);
    cardRectTransform.anchorMax = new Vector2(0, 0.5f);
    cardRectTransform.pivot = new Vector2(0, 0.5f);

    // Calculate the desired position based on the canvas width and card width
    float cardWidth = cardRectTransform.rect.width;
    float canvasWidth = canvasRectTransform.rect.width;
    float xOffset = cardWidth / 2f + 0f; // Adjust the offset as needed
    float desiredX = 265f;

    // Set the card's position to the desired position
    cardRectTransform.anchoredPosition = new Vector2(desiredX, 0f);

    // Set the scale of the card to be 25% bigger
    cardRectTransform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
}



    private string GetSelectedStat(GameObject card)
    {
        if (card != null)
        {
            // Assuming the card has a child object called "Stats" containing the stat texts
            Transform statsTransform = card.transform.Find("Stats");

            if (statsTransform != null)
            {
                // Assuming the selected stat text is the first child in the "Stats" object
                Transform selectedStatTransform = statsTransform.GetChild(0);

                if (selectedStatTransform != null)
                {
                    string selectedStat = selectedStatTransform.name.Replace("StatText", "");
                    return selectedStat;
                }
                else
                {
                    Debug.LogError("Selected stat text not found on the card.");
                }
            }
            else
            {
                Debug.LogError("Stats transform not found on the card.");
            }
        }
        else
        {
            Debug.LogError("Card is null.");
        }

        return string.Empty;
    }






    private void CompareStats(string selectedStat)
    {
        if (playerCard != null && aiCard != null)
        {
            int playerStatValue = GetStatValue(playerCard, selectedStat);
            int aiStatValue = GetStatValue(aiCard, selectedStat);

            if (playerStatValue > aiStatValue)
            {
                Debug.Log("Player wins!");
            }
            else if (playerStatValue < aiStatValue)
            {
                Debug.Log("AI wins!");
            }
            else
            {
                Debug.Log("It's a draw!");
            }

            // Switch turns
            CardDealer cardDealer = FindObjectOfType<CardDealer>();
            cardDealer.DealCards();
        }
        else
        {
            Debug.LogError("Player card or AI card is null.");
        }
    }

    private int GetStatValue(GameObject card, string statName)
    {
        if (card != null)
        {
            // Assuming the card has a child object called "Stats" containing the stat texts
            Transform statsTransform = card.transform.Find("Stats");

            if (statsTransform != null)
            {
                Transform statTextTransform = statsTransform.Find(statName + "StatText");

                if (statTextTransform != null)
                {
                    int.TryParse(statTextTransform.GetComponent<Text>().text, out int statValue);
                    return statValue;
                }
                else
                {
                    Debug.LogError("Stat text component not found for " + statName);
                }
            }
            else
            {
                Debug.LogError("Stats transform not found on the card.");
            }
        }
        else
        {
            Debug.LogError("Card is null.");
        }

        return 0;
    }
}
