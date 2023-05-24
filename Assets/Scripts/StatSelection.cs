using UnityEngine;
using UnityEngine.EventSystems;

public class StatSelection : MonoBehaviour, IPointerClickHandler
{
    public string statName; // Name of the stat associated with this UI element
    public string selectedStat;

    public void OnPointerClick(PointerEventData eventData)
    {
        // The player clicked on this stat
        // Implement the logic to handle the selection
        CardUI card = GetComponentInParent<CardUI>();
        if (card != null)
        {
            card.SelectStat(statName);
        }
    }

    public void OnMouseDown()
    {
        selectedStat = gameObject.name;
    }

  
}
