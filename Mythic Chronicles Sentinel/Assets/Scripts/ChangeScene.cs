using UnityEditor;
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

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ExitStage()
    {
        Time.timeScale = 1;
        GameObject musicObject = GameObject.FindWithTag("BackgroundMusic");
        AudioSource audioSource = musicObject.GetComponent<AudioSource>();
        audioSource.clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Music/Fiery_Greatsword.mp3");
        audioSource.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartStage(int sceneID)
    {
        Time.timeScale = 1;
        MoveToScene(sceneID);
    }
}