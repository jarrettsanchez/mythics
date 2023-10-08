using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Andre

public class StageTitle : MonoBehaviour
{
    public Text titleText;    
    private int stageNum;
    private AudioSource audioSource;    

    void Start()
    {
        getAudioSource();
        setTitleText();
    }

    void MoveToStage()
    {
        SceneManager.LoadScene(stageNum + 2);
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
