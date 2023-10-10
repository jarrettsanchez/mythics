using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject ArcherstatsPanel;

    [SerializeField]
    private GameObject SniperstatsPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowArcherStats()
    {
        ArcherstatsPanel.SetActive(!ArcherstatsPanel.activeSelf);
    }

    public void ShowSniperStats()
    {
        SniperstatsPanel.SetActive(!SniperstatsPanel.activeSelf);
    }
}
