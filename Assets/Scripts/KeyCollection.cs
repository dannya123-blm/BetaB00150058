// This code is based on from Create With Code Series:
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public AudioClip keyAudio;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the key
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with key.");

            // This updates the player's key count
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                playerInventory.CollectKey();
            }

            // Play the key collection sound
            if (audioSource != null && keyAudio != null)
            {
                Debug.Log("Playing key collection sound.");
                audioSource.PlayOneShot(keyAudio);
            }

            // Destroy the key object after a delay to allow the sound to play
            Destroy(gameObject, keyAudio.length);
        }
    }
}
