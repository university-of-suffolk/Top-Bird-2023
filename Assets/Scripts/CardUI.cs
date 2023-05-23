using UnityEngine;

public class CardUI : MonoBehaviour
{
    private bool isHovering = false;
    private Vector3 hoverOffset;
    private Transform startingParent;
    private CardDealer cardDealer; // Reference to the CardDealer script
    private int startingSortingOrder;

    private void Awake()
    {
        hoverOffset = Vector3.zero;
        cardDealer = FindObjectOfType<CardDealer>(); // Find the CardDealer script in the scene
        startingSortingOrder = GetComponent<Renderer>().sortingOrder;
        startingParent = transform.parent;
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

    public void OnPointerExit()
    {
        if (startingParent == cardDealer.playerPanel.transform && isHovering)
        {
            // Reset the position by subtracting the hover offset
            transform.localPosition -= hoverOffset;
            hoverOffset = Vector3.zero;
            isHovering = false;
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
        centerWorldPosition.z = 0f; // Set the z position to 0 to avoid any depth issues

        // Find the playerPanel in the scene hierarchy
        GameObject playerPanel = GameObject.Find("playerPanel");
        if (playerPanel != null)
        {
            // Move the card to the center position only if it belongs to the playerPanel
            if (transform.IsChildOf(playerPanel.transform))
            {
                // Move the card to the center position
                transform.position = centerWorldPosition;

                // Enlarge the card by 50%
                transform.localScale *= 1.5f;

                // Adjust the sorting order to ensure the card is on top
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sortingOrder = GetHighestSortingOrder() + 1;
                }
            }
        }
        else
        {
            Debug.LogWarning("playerPanel not found!");
        }
    }



    private int GetHighestSortingOrder()
    {
        int highestSortingOrder = int.MinValue;

        // Find all the cards in the scene
        CardUI[] cards = FindObjectsOfType<CardUI>();

        foreach (CardUI card in cards)
        {
            Renderer cardRenderer = card.GetComponent<Renderer>();
            if (cardRenderer != null)
            {
                highestSortingOrder = Mathf.Max(highestSortingOrder, cardRenderer.sortingOrder);
            }
        }

        return highestSortingOrder;
    }

    public void ScaleDown(float scale)
    {
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}