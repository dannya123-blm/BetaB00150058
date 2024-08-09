// This code is based on from Create with code series & Robert Smith's Moodle page:
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar; // Reference to the health bar UI
    public AudioClip deathAudioClip;
    private AudioSource audioSource;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        // Player takes damage
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        healthBar.SetHealth(currentHealth, maxHealth); // Ensure correct parameters are passed

        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void RestoreHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth, maxHealth);
        Debug.Log("Health restored by " + amount + ". Current health: " + currentHealth);
    }

    void Die()
    {
        audioSource.PlayOneShot(deathAudioClip);
        StartCoroutine(WaitAndLoadGameOverScene());
    }

    IEnumerator WaitAndLoadGameOverScene()
    {
        yield return new WaitForSeconds(deathAudioClip.length + 2f);
        SceneManager.LoadScene("GameOver");
    }
}
