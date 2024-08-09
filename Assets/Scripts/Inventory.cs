// This code is based on from Create with code series & Robert Smith's Moodle page:
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Include this namespace for scene management

public class Inventory : MonoBehaviour
{
    public Text keyText;
    private int keysCollected = 0;
    private int totalKeys;

    // Public read-only properties to access the number of collected keys and total keys required
    public int KeysCollected => keysCollected;
    public int TotalKeys => totalKeys;

    private void Start()
    {
        SetTotalKeys(); // Set the total keys based on the active scene
        UpdateKeyText(); 
    }

    // Method to increment the number of collected keys
    public void CollectKey()
    {
        keysCollected++; // Increment the collected keys
        UpdateKeyText(); 
    }

    // Method to update the key text UI element
    private void UpdateKeyText()
    {
        keyText.text = "Keys: " + keysCollected + "/" + totalKeys;
    }

    // Method to check if all keys have been collected
    public bool HasAllKeys()
    {
        return keysCollected >= totalKeys;
    }

    // Method to set total keys based on the active scene
    private void SetTotalKeys()
    {
        string sceneName = SceneManager.GetActiveScene().name; // Get the active scene name
        if (sceneName == "Level_1")
        {
            totalKeys = 3; // Set total keys to 3 for level_1
        }
        else if (sceneName == "Level_2")
        {
            totalKeys = 5; // Set total keys to 5 for level_2
        }
        else
        {
            totalKeys = 0; // Default value if the scene is not recognized
        }
    }
}
