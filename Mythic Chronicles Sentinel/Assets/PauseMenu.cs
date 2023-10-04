using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    void Update()
    {
        HandleEscape();   
    }

    private void HandleEscape()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPausePanel();
        }
    }

    public void ShowPausePanel()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);

        if(!PausePanel.activeSelf)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
