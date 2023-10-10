using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Andre

public class OptionsMenu : MonoBehaviour
{
    public Canvas AudioCanvas;

    public void Start()
    {
        hideAudioCanvas();
    }

    public void showAudioCanvas()
    {
        AudioCanvas.enabled = true;
    }

    public void hideAudioCanvas()
    {
        AudioCanvas.enabled = false;
    }
}