// This code is based on from https://youtu.be/POq1i8FyRyQ?si=j5Qptbd0DywsHJyI:
//Make a TIMER & COUNTDOWN in 5 Mins | Unity Tutorial for Beginners

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; 
    [SerializeField] float remainingTime; 
    [SerializeField] float warningTime = 10f;
    [SerializeField] AudioClip warningClip; 
    private AudioSource audioSource; 
    private bool isWarningActive = false; // Flag to ensure the warning is triggered only once

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if there is remaining time
        if (remainingTime > 0)
        {
            // Decrease the remaining time by the time that has passed since the last frame
            remainingTime -= Time.deltaTime;

            // Check if the remaining time is less than or equal to the warning time and if the warning has not been triggered yet
            if (remainingTime <= warningTime && !isWarningActive)
            {
                isWarningActive = true; // Set the warning flag to true
                StartCoroutine(FlashWarningText()); // Start the coroutine to flash the text
                audioSource.PlayOneShot(warningClip); // Play the warning sound once
            }
        }
        else if (remainingTime <= 0)
        {
            // Ensure remaining time does not go below zero
            remainingTime = 0;
            timerText.color = Color.red; // Change the timer text color to red
            StartCoroutine(WaitAndLoadGameOverScene()); // Start the coroutine to wait and then load the GameOver scene
        }

        // Calculate the minutes and seconds from the remaining time
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // Update the timer text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Coroutine to flash the timer text color
    IEnumerator FlashWarningText()
    {
        while (remainingTime > 0)
        {
            timerText.color = Color.red; 
            yield return new WaitForSeconds(0.5f); 
            timerText.color = Color.white; 
            yield return new WaitForSeconds(0.5f); 
        }
    }

    // Coroutine to wait for 2 seconds and then load the GameOver scene
    IEnumerator WaitAndLoadGameOverScene()
    {
        yield return new WaitForSeconds(2f); 
        SceneManager.LoadScene("GameOver"); 
    }
}


