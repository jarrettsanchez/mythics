using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Andre

public class MusicController : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource backgroundMusic;

    void Start()
    {
        GameObject musicObject = GameObject.FindWithTag("BackgroundMusic");
        backgroundMusic = musicObject.GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Music Volume Changed") == 1)
        {
            float playerPrefVolume = PlayerPrefs.GetFloat("Music Volume");
            volumeSlider.value = playerPrefVolume;
            backgroundMusic.volume = playerPrefVolume;
        }
        else
        {
            volumeSlider.value = 0.5f;
            backgroundMusic.volume = 0.5f;
        }
    }

    public void updateVolume(float volume)
    {
        backgroundMusic.volume = volume;
        PlayerPrefs.SetFloat("Music Volume", volume);
        if (PlayerPrefs.GetInt("Music Volume Changed") != 1)
        {
            PlayerPrefs.SetInt("Music Volume Changed", 1);
        }
    }
}