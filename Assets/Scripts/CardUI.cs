using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    private bool isHovering = false;
    private Vector3 hoverOffset;
    private Transform startingParent;
    private CardDealer cardDealer; // Reference to the CardDealer script
    private int startingSortingOrder;
    public bool isEnlarged = false;
    private bool locked = false;
    private Vector3 originalScale;
    private Vector3 scaledDownScale;
    public GameObject playerPanelLocked;
    public GameObject buttons;
    GameObject go;

    private void Awake()
    {
        hoverOffset = Vector3.zero;
        cardDealer = FindObjectOfType<CardDealer>(); // Find the CardDealer script in the scene
        startingSortingOrder = GetComponent<Renderer>().sortingOrder;
        startingParent = transform.parent;
        originalScale = transform.localScale;
        scaledDownScale = originalScale * 1.00f; // Calculate the scaled-down scale
        playerPanelLocked = GameObject.Find("playerPanelLocked");
        playerPanelLocked.GetComponent<SpriteRenderer>().enabled = false;
        buttons.SetActive(false);
        go = GameObject.Find("Go");
    }

    

    private void Update()
    {
        if (playerPanelLocked.GetComponent<SpriteRenderer>().enabled)
        {
            locked = true;
        }
        else
        {
            locked = false;
        }
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
                if (isEnlarged && locked)
                {
                    // Restore the card's original position and scale
                    transform.SetParent(startingParent);
                    transform.localPosition = Vector3.zero;
                    transform.localScale = scaledDownScale; // Change the scale to the scaled down size

                    // Adjust the sorting order to ensure the card is in the correct order
                    Renderer renderer = GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.sortingOrder = startingSortingOrder;
                    }

                    // Refresh the layout of the playerPanel
                    LayoutRebuilder.ForceRebuildLayoutImmediate(playerPanel.GetComponent<RectTransform>());

                    buttons.SetActive(false);
                    isEnlarged = false;                    
                    playerPanelLocked.GetComponent<SpriteRenderer>().enabled = false;
                    go.GetComponent<Image>().enabled = false;
                }
                if (!isEnlarged && !locked)
                {
                    // Enlarge the card by 25%
                    transform.localScale = originalScale * 1.25f;

                    // Adjust the sorting order to ensure the card is on top
                    Renderer renderer = GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        // Set the sorting order to a high value to make it appear on top
                        renderer.sortingOrder = 999;
                    }

                    // Move the card to the right middle position of the camera
                    transform.position = new Vector3(centerWorldPosition.x + 4f, centerWorldPosition.y, -1f);

                    buttons.SetActive(true);
                    isEnlarged = true;                    
                    playerPanelLocked.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
        else
        {
            Debug.LogWarning("playerPanel not found!");
        }
    }








    public void ScaleDown(float scale)
    {
        transform.localScale = new Vector3(scale, scale, 1f);
    }

    private int GetHighestSortingOrder(GameObject parent)
    {
        int highestSortingOrder = int.MinValue;

        CardUI[] cards = parent.GetComponentsInChildren<CardUI>();
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

    public void SelectStat(string statName)
{
    Debug.Log("Player selected Stat: " + statName);

    // TODO: Implement the logic to compare the selected stat with the AI's stat and determine the winner

    // TODO: Implement the logic to switch turns between the player and the AI
}

}
