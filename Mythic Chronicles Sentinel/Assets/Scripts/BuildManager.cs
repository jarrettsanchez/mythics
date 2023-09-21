using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] towers;

    private int selectedDefender = 0;

    private void Awake()
    {
        main = this;
    }

    public Tower GetSelectedDefender()
    {
        return towers[selectedDefender];
    }

    public void SetSelectedDefender(int _selectedDefender)
    {
        selectedDefender = _selectedDefender;
    }
}
