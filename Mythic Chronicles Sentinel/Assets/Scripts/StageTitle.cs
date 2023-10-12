using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

//Andre

public class StageTitle : MonoBehaviour
{
    public Text titleText;
    private int stageNum;
    private AudioSource audioSource;
    private float currentVolume;
    private float volumeChangeRate;
    private float timer = 0;

    void Start()
    {
        getAudioSource();
        setTitleText();
        currentVolume = audioSource.volume;
        volumeChangeRate = currentVolume / 10;
    }

    void Update()
    {
        if (audioSource.volume >= volumeChangeRate)
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

    void MoveToStage()
    {
        SceneManager.LoadScene(stageNum + 2);
        if (stageNum >= 1 && stageNum <= 3)
        {
            audioSource.clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Music/Suspicious_tool_shop.mp3");
        }
        audioSource.volume = currentVolume;
        audioSource.Play();
    }

    void getAudioSource()
    {
        GameObject musicObject = GameObject.FindWithTag("BackgroundMusic");
        audioSource = musicObject.GetComponent<AudioSource>();
    }

    void setTitleText()
    {
        stageNum = PlayerPrefs.GetInt("Stage");
        titleText.text = "STAGE " + stageNum + ":\n";
        if (stageNum >= 1 && stageNum <= 3)
        {
            titleText.text = titleText.text + "FARMLANDS";
        }
    }
}