using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;

    private bool isInvOpen = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        isInvOpen = !isInvOpen;
        anim.SetBool("InvOpen", isInvOpen);
    }

    private void OnGUI()
    {
        currencyUI.text = "$"+LevelManager.main.currency.ToString();
    }
}
