// This code is based on from Create With Code Series:
using UnityEngine;

public class Portal : MonoBehaviour
{
    // This method is called when another collider enters the trigger collider attached to the GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Get the Inventory component from the player GameObject
            Inventory inventory = other.GetComponent<Inventory>();

            // Check if the player has an Inventory component and if the player has collected all keys
            if (inventory != null && inventory.KeysCollected >= inventory.TotalKeys)
            {
                // Get the PortalInteraction component attached to the same GameObject
                PortalInteraction portalInteraction = GetComponent<PortalInteraction>();

                // Check if the PortalInteraction component exists
                if (portalInteraction != null)
                {
                    // Start the coroutine to activate the portal
                    StartCoroutine(portalInteraction.ActivatePortal());
                }
                else
                {
                    Debug.LogError("PortalInteraction component not found!");
                }
            }
            else
            {
                Debug.Log("Not all keys collected!");
            }
        }
    }
}
