using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public bool destroyOnCollision = false;  // Whether the enemy should be destroyed upon collision
    public float moveSpeed = 3f;
    private Transform playerTransform;
    private bool isGrounded = false;

    private void Start()
    {
        // Find the player GameObject by tag
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Move towards the player only if the enemy is grounded
        if (playerTransform != null && isGrounded)
        {
            Vector3 direction = new Vector3(playerTransform.position.x - transform.position.x, 0, 0).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
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
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
