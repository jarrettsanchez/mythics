using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageTitle : MonoBehaviour
{
    public Text titleText;
    public Animator animator;
    private int stageNum;

    // Start is called before the first frame update
    void Start()
    {
        stageNum = PlayerPrefs.GetInt("Stage");
        if (stageNum == 1)
        {
            titleText.text = "STAGE 1:\nFARMLANDS";
        }        
    }

    public void MoveToStage()
    {
        SceneManager.LoadScene(stageNum + 2);
    }
}
