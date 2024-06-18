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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory != null)
            {
                if (inventory.HasAllKeys())
                {
                    StartCoroutine(ActivatePortal());
                }
                else
                {
                    FailToActivatePortal();
                }
            }
        }
    }

    public IEnumerator ActivatePortal()
    {
        // Play success sound
        if (EnterPortalAudio != null)
        {
            audioSource.PlayOneShot(EnterPortalAudio);
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level_2");
    }

    private void FailToActivatePortal()
    {
        // Play fail sound
        if (NotEnterPortal != null)
        {
            audioSource.PlayOneShot(NotEnterPortal);
        }
    }
}
