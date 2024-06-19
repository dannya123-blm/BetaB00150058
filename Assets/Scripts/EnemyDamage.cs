// This code is based on from Create With Code Series:

using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public bool destroyOnCollision = false; 
    public float moveSpeed = 3f;
    private Transform playerTransform;
    private bool isGrounded = false; 


    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Move towards the player only if the enemy is grounded
        if (playerTransform != null && isGrounded)
        {
            // Calculate direction towards the player
            Vector3 direction = new Vector3(playerTransform.position.x - transform.position.x, 0, 0).normalized;

            // Move the enemy towards the player
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    // Called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set isGrounded to true when colliding with the ground
        }
        // Check if the enemy collides with the player
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Inflict damage to the player
                playerHealth.TakeDamage(damageAmount);

                // Destroy the enemy if needed
                if (destroyOnCollision)
                {
                    Destroy(gameObject); // Destroy the enemy GameObject
                }
            }
        }
    }

    // Called when this collider/rigidbody has stopped touching another rigidbody/collider
    private void OnCollisionExit(Collision collision)
    {
        // Check if the enemy stops colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Set isGrounded to false when not colliding with the ground
        }
    }
}
