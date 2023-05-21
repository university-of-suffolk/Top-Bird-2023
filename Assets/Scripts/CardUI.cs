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

    private Vector3 hoverOffset;

    private void Awake()
    {
        hoverOffset = Vector3.zero;
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
}
