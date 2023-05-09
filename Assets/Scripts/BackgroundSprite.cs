using UnityEngine;

public class BackgroundSprite : MonoBehaviour
{
    // Array to hold the background images
    public Sprite[] backgrounds;

    void Start()
    {
        // Generate a random number to select a background image
        int randomIndex = Random.Range(0, backgrounds.Length);

        // Set the sprite of the Sprite Renderer component to the selected background image
        GetComponent<SpriteRenderer>().sprite = backgrounds[randomIndex];
    }
}
