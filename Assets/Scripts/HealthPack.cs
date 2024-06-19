// This code is based on from Create With Code Series - Unit 4 Powerups:
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healthAmount = 20; // Amount of health to restore

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.RestoreHealth(healthAmount);
            }
            Destroy(gameObject); // Destroy the health pack after collection
        }
    }
}
