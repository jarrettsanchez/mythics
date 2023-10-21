using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Security.Cryptography.X509Certificates;

//Andre

public class StageTitle : MonoBehaviour
{
    public Text titleText;
    private bool changeMusic = false;
    private int stageNum;
    private AudioSource audioSource;
    private float currentVolume;
    private float volumeChangeRate;
    private float timer = 0;

    void Start()
    {        
        setTitleText();
        if (PlayerPrefs.GetInt("Change Music") == 1 || stageNum % 3 == 1)
        {
            changeMusic = true;
            getAudioSource();
            currentVolume = audioSource.volume;
            volumeChangeRate = currentVolume / 10;
        }
    }

    void Update()
    {
        if (changeMusic && audioSource.volume >= volumeChangeRate)
        {
            if (timer > 0.2)
            {
                audioSource.volume -= volumeChangeRate;
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }        
    }

    void setTitleText()
    {
        stageNum = PlayerPrefs.GetInt("Stage");
        titleText.text = "STAGE " + stageNum + ":\n";
        string stageName = "";
        switch (stageNum)
        {
            case 1:
            case 2:
            case 3:
                stageName = "FARMLANDS";
                break;
            case 4:
            case 5:
            case 6:
                stageName = "FORREST";
                break;
            case 7:
            case 8:
            case 9:
                stageName = "MEADOW";
                break;
        }
        titleText.text = titleText.text + stageName;
    }

    void getAudioSource()
    {
        GameObject musicObject = GameObject.FindWithTag("BackgroundMusic");
        audioSource = musicObject.GetComponent<AudioSource>();
    }

    void MoveToStage()
    {
        SceneManager.LoadScene(stageNum + 2);
        if (changeMusic)
        {
            PlayerPrefs.SetInt("Change Music", 0);
            string musicFile = "Assets/Music/";
            switch (stageNum)
            {
                case 1:
                case 2:
                case 3:
                    musicFile += "Suspicious_tool_shop.mp3";
                    break;
                case 4:
                case 5:
                case 6:
                    musicFile += "Aged_Forest.mp3";
                    break;
                case 7:
                case 8:
                case 9:
                    musicFile += "Feel_the_wind.mp3";
                    break;
            }
            audioSource.clip = AssetDatabase.LoadAssetAtPath<AudioClip>(musicFile);
            audioSource.volume = currentVolume;
            audioSource.Play();
        }        
    }
}