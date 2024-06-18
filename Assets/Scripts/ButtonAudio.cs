using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip HoverButton; // Correct name for hover sound
    public AudioClip NStartButton; // Correct name for click sound
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverSound();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayClickSound();
    }

    public void PlayHoverSound()
    {
        if (HoverButton != null)
        {
            audioSource.PlayOneShot(HoverButton);
        }
    }

    public void PlayClickSound()
    {
        if (NStartButton != null)
        {
            audioSource.PlayOneShot(NStartButton);
        }
    }
}
