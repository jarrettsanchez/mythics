using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressSlider;

    public void SetHealth(int progress)
    {
        progressSlider.value = progress;
    }

    public void SetMaxHealth(int progress)
    {
        progressSlider.maxValue = progress;
        progressSlider.value = progress;
    }
}
