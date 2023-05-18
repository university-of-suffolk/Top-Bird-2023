//using UnityEngine;
//using UnityEngine.UI;

//public class CardPrefabController : MonoBehaviour
//{
//    public Image baseColorImage;
//    public Image cardImage;
//    public Text cardNameText;
//    public Text speedText;
//    public Text sizeText;
//    public Text strengthText;
//    public Text weightText;
//    public Text wingspanText;

//    private int cardIndex;

//    public void SetCardIndex(int index)
//    {
//        cardIndex = index;
//        SetCardData(); // Call SetCardData() after setting the card index
//    }

//    public void SetCardData()
//    {
//        Debug.Log("Card Index: " + cardIndex);

//        if (baseColorImage == null)
//        {
//            Debug.LogError("Base color image reference is null.");
//            return;
//        }

//        if (cardIndex < 0 || cardIndex >= CardDataBase.cardList.Count)
//        {
//            Debug.LogError("Invalid card index: " + cardIndex);
//            return;
//        }

//        Card cardData = CardDataBase.cardList[cardIndex];

//        if (cardData == null)
//        {
//            Debug.LogError("Card data is null.");
//            return;
//        }

//        baseColorImage.color = GetColorFromName(cardData.baseColor); // Set the base color

//        if (cardImage != null)
//        {
//            cardImage.sprite = cardData.cardImage;
//        }
//        else
//        {
//            Debug.LogWarning("Card image reference is null.");
//        }

//        if (cardNameText != null)
//        {
//            cardNameText.text = cardData.cardName;
//        }
//        else
//        {
//            Debug.LogWarning("Card name text reference is null.");
//        }

//        if (speedText != null)
//        {
//            speedText.text = "Speed: " + cardData.speed.ToString();
//        }
//        else
//        {
//            Debug.LogWarning("Speed text reference is null.");
//        }

//        if (sizeText != null)
//        {
//            sizeText.text = "Size: " + cardData.size.ToString();
//        }
//        else
//        {
//            Debug.LogWarning("Size text reference is null.");
//        }

//        if (strengthText != null)
//        {
//            strengthText.text = "Strength: " + cardData.strength.ToString();
//        }
//        else
//        {
//            Debug.LogWarning("Strength text reference is null.");
//        }

//        if (weightText != null)
//        {
//            weightText.text = "Weight: " + cardData.weight.ToString();
//        }
//        else
//        {
//            Debug.LogWarning("Weight text reference is null.");
//        }

//        if (wingspanText != null)
//        {
//            wingspanText.text = "Wingspan: " + cardData.wingspan.ToString();
//        }
//        else
//        {
//            Debug.LogWarning("Wingspan text reference is null.");
//        }

//        DisplayCardData();
//    }

//    private Color GetColorFromName(string colorName)
//    {
//        Color color = Color.grey; // Default color if no matching name is found

//        // Map color names to actual colors
//        switch (colorName)
//        {
//            case "Grey":
//                color = Color.grey;
//                break;
//            case "Blue":
//                color = Color.blue;
//                break;
//            case "Red":
//                color = Color.red;
//                break;
//            case "Green":
//                color = Color.green;
//                break;
//            case "Gold":
//                color = new Color(1.0f, 0.84f, 0.0f); // RGB values for gold color
//                break;
//            case "Rainbow":
//                color = new Color(0.75f, 0.0f, 0.75f); // RGB values for rainbow color
//                break;
//        }

//        return color;
//    }

//    private void DisplayCardData()
//    {
//        // Display the card data
//        baseColorImage.gameObject.SetActive(true);

//        if (cardImage != null)
//            cardImage.gameObject.SetActive(true);

//        if (cardNameText != null)
//            cardNameText.gameObject.SetActive(true);

//        if (speedText != null)
//            speedText.gameObject.SetActive(true);

//        if (sizeText != null)
//            sizeText.gameObject.SetActive(true);

//        if (strengthText != null)
//            strengthText.gameObject.SetActive(true);

//        if (weightText != null)
//            weightText.gameObject.SetActive(true);

//        if (wingspanText != null)
//            wingspanText.gameObject.SetActive(true);
//    }
//}
