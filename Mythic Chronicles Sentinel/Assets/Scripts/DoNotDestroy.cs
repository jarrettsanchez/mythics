using UnityEngine;

//Andre

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if (musicObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Music Volume Changed", 0);
    }
}