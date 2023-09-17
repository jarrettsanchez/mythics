using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private int price;

    [SerializeField]
    private TextMeshProUGUI priceText;

    public int Price
    {
        get
        {
            return price;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab;
        }
    }

    private void Start()
    {
        priceText.text = price + "$";
    }
}
