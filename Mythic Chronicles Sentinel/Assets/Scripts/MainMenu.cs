using UnityEngine;

//Andre

public class MainMenu : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        if (PlayerPrefs.GetInt("Stage") > 1)
        {
            canvas.enabled = true;            
        }
        else
        {
            canvas.enabled = false;            
        }
    }
}
