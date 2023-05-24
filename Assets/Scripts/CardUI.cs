// CardUI.cs

using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    private bool isHovering = false;
    private Vector3 hoverOffset;
    private Transform startingParent;
    private CardDealer cardDealer; // Reference to the CardDealer script
    private int startingSortingOrder;
    private bool isEnlarged = false;
    private Vector3 originalScale;
    private Vector3 scaledDownScale;
    private bool playerGoesFirst = true;
    public GameObject confirmButtonsPrefab;
    private GameObject confirmButtons;
    public GameObject playerPanel;

    public int selectedStatValue;

    private void Awake()
    {
        hoverOffset = Vector3.zero;
        cardDealer = FindObjectOfType<CardDealer>(); // Find the CardDealer script in the scene
        startingSortingOrder = GetComponent<Renderer>().sortingOrder;
        startingParent = transform.parent;
        originalScale = transform.localScale;
        scaledDownScale = originalScale * 0.75f; // Calculate the scaled-down scale
    }

    public void OnPointerEnter()
    {
        if (startingParent == cardDealer.playerPanel.transform && !isHovering)
        {
            // Store the current position as the hover offset
            hoverOffset = Vector3.up * 10f;
            transform.localPosition += hoverOffset;
            isHovering = true;
        }
    }

    public void OnPointerClick()
    {
        Debug.Log("Card clicked!");

        // Get the main camera
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogWarning("Main camera not found!");
            return;
        }

        // Calculate the center position of the screen
        Vector3 centerScreenPosition = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);

        // Convert the center position from screen space to world space
        Vector3 centerWorldPosition = mainCamera.ScreenToWorldPoint(centerScreenPosition);

        // Find the playerPanel in the scene hierarchy
        GameObject playerPanel = GameObject.Find("playerPanel");
        if (playerPanel != null)
        {
            // Move the card to the right middle position only if it belongs to the playerPanel
            if (transform.IsChildOf(playerPanel.transform))
            {
                if (isEnlarged)
                {
                    // Restore the card's original position and scale
                    transform.SetParent(startingParent);
                    transform.localPosition = Vector3.zero;
                    transform.localScale = scaledDownScale; // Change the scale to the scaled-down size

                    // Adjust the sorting order to ensure the card is in the correct order
                    Renderer renderer = GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.sortingOrder = startingSortingOrder;
                    }

                    // Refresh the layout of the playerPanel
                    LayoutRebuilder.ForceRebuildLayoutImmediate(playerPanel.GetComponent<RectTransform>());

                    isEnlarged = false;
                }
                else
                {
                    // Enlarge the card by 25%
                    transform.localScale = originalScale * 0.95f;

                    // Adjust the sorting order to ensure the card is on top
                    Renderer renderer = GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        // Set the sorting order to a high value to make it appear on top
                        renderer.sortingOrder = 999;
                    }

                    // Move the card to the right middle position of the camera
                    transform.position = new Vector3(centerWorldPosition.x + 4f, centerWorldPosition.y, -1f);

                    isEnlarged = true;
                }
            }
        }
        else
        {
            Debug.LogWarning("playerPanel not found!");
        }

        if (startingParent == cardDealer.playerPanel.transform && isEnlarged)
        {
            // Create the confirm buttons
            confirmButtons = Instantiate(confirmButtonsPrefab, transform.position + Vector3.right * 2.5f, Quaternion.identity);
            confirmButtons.transform.SetParent(transform);
        }
    }


    public void ScaleDown(float scale)
    {
        transform.localScale *= scale;
    }

    public void SelectStat(string statName)
    {
        Debug.Log("Selected stat: " + statName);

        // Get the selected stat value from the player's card
        Text statText = GetComponentInChildren<Text>();
        if (statText != null && statText.gameObject.name == statName)
        {
            selectedStatValue = int.Parse(statText.text);
            Debug.Log("Selected stat value: " + selectedStatValue);

            // Compare the selected stat value with the AI's stat value
            CompareStats(statName);

            // Determine the next turn
            playerGoesFirst = (transform.parent == cardDealer.playerPanel.transform);

            // Start the AI's turn if it's their turn
            if (!playerGoesFirst)
            {
                cardDealer.StartCoroutine(cardDealer.AITurnCoroutine());
            }
        }
    }

    private void CompareStats(string statName)
    {
        // Retrieve the AI's stat value for the selected stat
        int aiStatValue = GetRandomAIStatValue();

        // Compare the player's stat value with the AI's stat value
        if (selectedStatValue > aiStatValue)
        {
            Debug.Log("Player wins!");
        }
        else if (selectedStatValue < aiStatValue)
        {
            Debug.Log("AI wins!");
        }
        else
        {
            Debug.Log("It's a draw!");
        }
    }

    private int GetRandomAIStatValue()
    {
        // Generate a random number between 1 and 10 as the AI's stat value
        return Random.Range(1, 11);
    }

    public void ConfirmSelection(bool confirm)
    {
        if (confirm)
        {
            Debug.Log("Selection confirmed!");

            // Remove the confirm buttons
            Destroy(confirmButtons);

            // Get the selected stat value from the player's card
            Text statText = GetComponentInChildren<Text>();
            if (statText != null)
            {
                selectedStatValue = int.Parse(statText.text);
                Debug.Log("Selected stat value: " + selectedStatValue);

                // Determine the next turn
                playerGoesFirst = (transform.parent == cardDealer.playerPanel.transform);

                // Start the AI's turn if it's their turn
                if (!playerGoesFirst)
                {
                    cardDealer.StartCoroutine(cardDealer.AITurnCoroutine());
                }
            }
        }
        else
        {
            Debug.Log("Selection canceled!");

            // Remove the confirm buttons
            Destroy(confirmButtons);

            // Return the card to its original position and scale
            transform.SetParent(startingParent);
            transform.localPosition = Vector3.zero;
            transform.localScale = originalScale;

            // Adjust the sorting order to ensure the card is in the correct order
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sortingOrder = startingSortingOrder;
            }

            // Refresh the layout of the playerPanel
            LayoutRebuilder.ForceRebuildLayoutImmediate(playerPanel.GetComponent<RectTransform>());

            isEnlarged = false;
        }
    }

}
