using System.Collections;
using System.Collections.Generic;
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

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
