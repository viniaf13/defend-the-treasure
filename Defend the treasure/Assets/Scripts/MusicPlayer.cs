using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] soundtracks = default;
    [SerializeField] AudioClip loseSound = default;
    [SerializeField] AudioClip winSound = default;
    AudioSource audioSource;

    private int currentSoundtrack = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void ChangeSoundtrack(int levelNumber)
    {
        if (currentSoundtrack == levelNumber) return;

        currentSoundtrack = levelNumber;
        audioSource.clip = soundtracks[currentSoundtrack];
        audioSource.Play();
    }
    public void PlayWinnerSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
    }
    public void PlayLoserSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(loseSound);
    }
    public void PlayCurrentSoundtrack()
    {
        audioSource.Play();
    }


    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    
}
