using UnityEngine;
using UnityEngine.EventSystems;

public class ParticleScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ParticleSystem particles;

    public void OnPointerEnter (PointerEventData eventData)
    {
        particles.Play();
    }

    public void OnPointerExit ( PointerEventData eventData)
    {
        particles.Stop();
    }    
}