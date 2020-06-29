using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = default;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] Slider difficultySlider = default;
    [SerializeField] float defaultDifficulty = 1f;

    MusicPlayer musicPlayer;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
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
    }

    public void SaveOptionPrefs()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
