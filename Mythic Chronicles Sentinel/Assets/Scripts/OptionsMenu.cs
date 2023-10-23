using UnityEngine;
using UnityEngine.UI;

//Andre

public class OptionsMenu : MonoBehaviour
{
    public Canvas audioCanvas;
    public Canvas confirmDeleteCanvas;
    public Button deleteSaveButton;    
    public Slider volumeSlider;
    private AudioSource backgroundMusic;

    void Start()
    {
        hideCanvas(audioCanvas);
        hideCanvas(confirmDeleteCanvas);
        hasVolumeChanged();
        if (PlayerPrefs.GetInt("Stage") > 1)
        {
            deleteSaveButton.interactable = true;
        }
        else
        {
            deleteSaveButton.interactable = false;
        }
    }

    public void showCanvas(Canvas canvas)
    {
        canvas.enabled = true;        
    }

    public void hideCanvas(Canvas canvas)
    {
        canvas.enabled = false;
    }

    public void deleteSave(Canvas canvas)
    {
        PlayerPrefs.SetInt("Stage", 1);
        deleteSaveButton.interactable = false;
        hideCanvas(canvas);
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