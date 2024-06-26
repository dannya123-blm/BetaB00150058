// This code is based on from Create With Code Series:
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PortalInteraction : MonoBehaviour
{
    public AudioClip EnterPortalAudio;
    public AudioClip NotEnterPortal;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This method is called when another collider enters the trigger collider attached to the GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Get the Inventory component from the player GameObject
            Inventory inventory = other.GetComponent<Inventory>();

            // Check if the player has an Inventory component
            if (inventory != null)
            {
                // Check if the player has all the keys required to activate the portal
                if (inventory.HasAllKeys())
                {
                    // Start the coroutine to activate the portal
                    StartCoroutine(ActivatePortal());
                }
                else
                {
                    // Play the fail sound if the player doesn't have all keys
                    FailToActivatePortal();
                }
            }
        }
    }

    // Coroutine to handle the portal activation process
    public IEnumerator ActivatePortal()
    {
        // Play the success sound if the audio clip is assigned
        if (EnterPortalAudio != null)
        {
            audioSource.PlayOneShot(EnterPortalAudio);
        }

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Get the name of the current active scene
        string currentScene = SceneManager.GetActiveScene().name;

        // Check the name of the current scene and load the appropriate next scene
        if (currentScene == "Level_1")
        {
            SceneManager.LoadScene("Level_2"); // Load Level_2 if currently in Level_1
        }
        else if (currentScene == "Level_2")
        {
            SceneManager.LoadScene("GameOver"); // Load GameOver if currently in Level_2
        }
    }

    // Method to handle the fail sound when the portal cannot be activated
    private void FailToActivatePortal()
    {
        // Play the fail sound if the audio clip is assigned
        if (NotEnterPortal != null)
        {
            audioSource.PlayOneShot(NotEnterPortal);
        }
    }
}
