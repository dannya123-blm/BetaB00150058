using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle audioToggle;
    private AudioSource backgroundMusic;

    void Start()
    {
        // Find the AudioSource component on the BackgroundMusic GameObject
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        // Load saved audio setting
        bool isAudioEnabled = PlayerPrefs.GetInt("AudioEnabled", 1) == 1;
        audioToggle.isOn = isAudioEnabled;

        // Apply the initial settings
        OnAudioToggle(isAudioEnabled);

 
        audioToggle.onValueChanged.AddListener(delegate { OnAudioToggle(audioToggle.isOn); });
    }

    public void OnAudioToggle(bool isOn)
    {
        // Save the audio setting
        PlayerPrefs.SetInt("AudioEnabled", isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Mute or unmute the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = !isOn;
        }
    }

    public void ToggleAudio()
    {
        if (backgroundMusic != null)
        {
            bool isMuted = !backgroundMusic.mute;
            backgroundMusic.mute = isMuted;

            // Save the audio setting
            PlayerPrefs.SetInt("AudioEnabled", isMuted ? 0 : 1);
            PlayerPrefs.Save();
        }
    }
}
