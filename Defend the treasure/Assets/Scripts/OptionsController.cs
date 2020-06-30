using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = default;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] Slider difficultySlider = default;
    [SerializeField] Text difficultyText = default;
    [SerializeField] float defaultDifficulty = 1f;

    MusicPlayer musicPlayer;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetGameDifficulty();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
        UpdateDifficultyText();
    }

    public void SaveOptionPrefs()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetGameDifficulty(difficultySlider.value);
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public void UpdateDifficultyText()
    {
        float diff = difficultySlider.value;
        switch (diff)
        {
            case 1f:
                difficultyText.text = "I'm afraid of games";
                break;
            case 2f:
                difficultyText.text = "Normal";
                break;
            case 3f:
                difficultyText.text = "King of the Pirates";
                break;
        }
    }
}
