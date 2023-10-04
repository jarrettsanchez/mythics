using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject statsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStats()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
    }
}
