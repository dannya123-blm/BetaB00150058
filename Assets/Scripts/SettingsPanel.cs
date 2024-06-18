using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public GameObject settingsPanel;

    void Start()
    {
        settingsPanel.SetActive(false); // Ensure the settings panel is hidden initially
    }

    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}
