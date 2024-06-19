using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Text keyText;
    private int keysCollected = 0;
    private int totalKeys = 5;

    // Public read-only properties to access the number of collected keys and total keys required
    public int KeysCollected => keysCollected;
    public int TotalKeys => totalKeys;

    private void Start()
    {
        UpdateKeyText();
    }

    // Method to increment the number of collected keys
    public void CollectKey()
    {
        keysCollected++; // Increment the collected keys
        UpdateKeyText(); // Update the key text
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
}
