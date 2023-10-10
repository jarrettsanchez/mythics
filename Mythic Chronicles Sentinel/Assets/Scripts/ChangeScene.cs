using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//Andre

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Stage", 1);
        SceneManager.LoadScene("Stage Title");
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