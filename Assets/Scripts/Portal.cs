using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null && inventory.keysCollected >= inventory.totalKeys)
            {
                // Start the portal interaction coroutine if it exists
                PortalInteraction portalInteraction = GetComponent<PortalInteraction>();
                if (portalInteraction != null)
                {
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
