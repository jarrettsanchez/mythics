using UnityEngine;
using UnityEngine.UI;

//Andre

public class OptionsMenu : MonoBehaviour
{
    public Button deleteSaveButton;
    public Canvas AudioCanvas;
    public Slider volumeSlider;
    private AudioSource backgroundMusic;

    void Start()
    {
        hideAudioCanvas();
        hasVolumeChanged();
        if (PlayerPrefs.GetInt("Stage") > 1)
        {
            deleteSaveButton.enabled = true;
        }
    }

    public void showAudioCanvas()
    {
        AudioCanvas.enabled = true;
    }

    public void hideAudioCanvas()
    {
        AudioCanvas.enabled = false;
    }

    public void deleteSave()
    {
        PlayerPrefs.SetInt("Stage", 1);
        deleteSaveButton.enabled = false;
    }

    private void hasVolumeChanged()
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