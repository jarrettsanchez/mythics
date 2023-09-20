using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] defenderPrefabs;

    private int selectedDefender = 0;

    private void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedDefender()
    {
        return defenderPrefabs[selectedDefender];
    }
}
