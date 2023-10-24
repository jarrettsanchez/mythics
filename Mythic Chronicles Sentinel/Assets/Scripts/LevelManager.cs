using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform[] path;
    public Transform startPoint;

    public int currency;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 5;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= currency)
        {
            //buy
            currency -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}