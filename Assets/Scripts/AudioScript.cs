using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip drawClip;
    public AudioClip cardFlipClip;

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winClip);
    }

    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(loseClip);
    }

    public void PlayDrawSound()
    {
        audioSource.PlayOneShot(drawClip);
    }

    public void PlayCardFlipSound()
    {
        audioSource.PlayOneShot(cardFlipClip);
    }
}
