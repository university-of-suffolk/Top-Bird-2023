using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text nameText;
    public Text speedText;
    public Text wingspanText;
    public Text strengthText;
    public Text sizeText;
    public Text weightText;
    public Image cardImage;
    public Image frameImage;

    private bool dealt = false;

    private Vector3 hoverOffset;
    private Vector3 startingPoint;
    private CardDealer cardDealer; // Reference to the CardDealer script

    private void Awake()
    {
        hoverOffset = Vector3.zero;
        cardDealer = FindObjectOfType<CardDealer>(); // Find the CardDealer script in the scene
    }

    public void SetCardData(Card card)
    {
        nameText.text = card.cardName;
        speedText.text = "Speed: " + card.speed;
        wingspanText.text = "Wingspan: " + card.wingspan;
        strengthText.text = "Strength: " + card.strength;
        sizeText.text = "Size: " + card.size;
        weightText.text = "Weight: " + card.weight;
        cardImage.sprite = card.thisImage;

        // Set frame color or material based on card color
        if (card.color == "Grey")
        {
            frameImage.color = new Color32(128, 128, 128, 255);
        }
        else if (card.color == "Blue")
        {
            frameImage.color = new Color32(135, 206, 250, 255);
        }
        else if (card.color == "Red")
        {
            frameImage.color = new Color32(220, 20, 60, 255);
        }
        else if (card.color == "Green")
        {
            frameImage.color = new Color32(173, 255, 47, 255);
        }
        else if (card.color == "Gold")
        {
            frameImage.color = new Color32(212, 175, 55, 255);
        }
        else if (card.color == "Rainbow")
        {
            Material rainbowMaterial = Resources.Load<Material>("Rainbow");
            frameImage.material = rainbowMaterial;
        }
    }

    public void ScaleDown(float scale)
    {
        transform.localScale = new Vector3(scale, scale, 1f);
    }

    public void OnPointerEnter()
    {
        // Store the current position as the hover offset
        hoverOffset = Vector3.up * 30f;
        transform.position += hoverOffset;
    }

    public void OnPointerExit()
    {
        // Reset the position by subtracting the hover offset
        transform.position -= hoverOffset;
        hoverOffset = Vector3.zero;
    }

    //public void OnPointerClick()
    //{
    //    // Check if the card is already in the player panel or AI panel
    //    Transform playerPanelTransform = cardDealer.playerPanel.transform;
    //    Transform aiPanelTransform = cardDealer.aiPanel.transform;
    //    bool isInPlayerPanel = transform.IsChildOf(playerPanelTransform);
    //    bool isInAiPanel = transform.IsChildOf(aiPanelTransform);

    //    // Store the starting position
    //    startingPoint = transform.position;

    //    if (isInPlayerPanel || isInAiPanel)
    //    {
    //        // Move the card back to its original panel
    //        transform.SetParent(isInPlayerPanel ? playerPanelTransform : aiPanelTransform);
    //        transform.localScale = Vector3.one;
    //    }
    //    else
    //    {
    //        // Calculate the center position of the screen in world coordinates
    //        Vector3 centerScreenPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));

    //        // Add an offset to the vertical position
    //        centerScreenPosition.y += 450f;
    //        centerScreenPosition.x += 975;

    //        // Move the card to the center of the screen
    //        transform.position = centerScreenPosition;
    //    }
    //}

    public void OnPointerClick()
    {
        Transform playerPanelTransform = cardDealer.playerPanel.transform;
        Transform aiPanelTransform = cardDealer.aiPanel.transform;
        bool isInPlayerPanel = transform.IsChildOf(playerPanelTransform);
        bool isInAiPanel = transform.IsChildOf(aiPanelTransform);

        


        // Calculate the center position of the screen
        Vector3 centerScreenPosition = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));

        centerScreenPosition.y += 450;
        centerScreenPosition.x += 975;

        if(dealt)
        {
            transform.position = startingPoint;
            dealt = false;
        }
        else
        {
            // Store the starting position
            startingPoint = transform.position;
            transform.position = centerScreenPosition;
            dealt = true;
        }

    }

    public void OnPointerClickAgain()
    {
        
    }



}
