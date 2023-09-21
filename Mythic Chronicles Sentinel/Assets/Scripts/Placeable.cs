using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color restrictColor;

    private GameObject defender;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;

        Tower defenderToBuild = BuildManager.main.GetSelectedDefender();

        if(defenderToBuild.cost > LevelManager.main.currency)
        {
            sr.color = restrictColor;
        }
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if(defender != null)
        {
            return;
        }

        Tower defenderToBuild = BuildManager.main.GetSelectedDefender();

        if(defenderToBuild.cost > LevelManager.main.currency)
        {
            // dialogue box? to tell user they cannot buy any defenders
            return;
        }

        LevelManager.main.SpendCurrency(defenderToBuild.cost);

        defender = Instantiate(defenderToBuild.prefab, transform.position, Quaternion.identity);
    }
}
