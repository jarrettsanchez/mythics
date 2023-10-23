using UnityEngine;
using UnityEngine.SceneManagement;

//Andre

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID) 
    {
        SceneManager.LoadScene(sceneID);
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("Change Music", 1);
        SceneManager.LoadScene("Stage Title");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Stage", 1);
        LoadGame();
    }

    public void QuitGame() // Exits app.
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ExitStage() // Returns to Main Menu and returns to Main Menu music.
    {
        Time.timeScale = 1;
        GameObject musicObject = GameObject.FindWithTag("BackgroundMusic");
        AudioSource audioSource = musicObject.GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Fiery_Greatsword");
        audioSource.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void MoveToStage() // Transitions to game stage.
    {
        Time.timeScale = 1;
        int stageNum = PlayerPrefs.GetInt("Stage");
        string newStage = "";
        switch (stageNum)
        {
            case 1:
                newStage = "FarmlandsStage1";
                break;
            case 2:
                newStage = "FarmlandsStage2";
                break;
        }
        SceneManager.LoadScene(newStage);
    }
}