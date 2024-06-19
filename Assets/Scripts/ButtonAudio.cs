using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{

    public AudioClip HoverButton; 
    public AudioClip NStartButton;
    private AudioSource audioSource; 


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Called when the pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverSound();
    }

    // Called when the pointer clicks on the button
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayClickSound();
    }

    // Method to play the hover sound
    public void PlayHoverSound()
    {
        // Check if the hover sound clip is assigned
        if (HoverButton != null)
        {
            // Play the hover sound
            audioSource.PlayOneShot(HoverButton);
        }
    }

    // Method to play the click sound
    public void PlayClickSound()
    {
        // Check if the click sound clip is assigned
        if (NStartButton != null)
        {
            // Play the click sound
            audioSource.PlayOneShot(NStartButton);
        }
    }
}
