using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public TowerButton ClickedButton { get; set; }

    private int currency;

    [SerializeField]
    private TextMeshProUGUI currencyText;

    [SerializeField]
    private GameObject InGameOption;

    public int Currency
    {
        get
        {
            return currency;
        }
        set
        {
            this.currency = value;

            if (currencyText != null)
            {
                this.currencyText.text = value.ToString() + " $";
            }  
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Currency = 10;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();

        HandleRightClicked();
    }

    public void PickTower(TowerButton towerButton)
    {
        if (Currency >= towerButton.Price)
        {
            this.ClickedButton = towerButton;

            Hover.Instance.Activate(towerButton.Sprite);
        }
    }

    public void BuyTower()
    {
        if(Currency >= ClickedButton.Price)
        {
            Currency -= ClickedButton.Price;

            Hover.Instance.Deactivate();
        }
    }

    private void HandleRightClicked()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Hover.Instance.Deactivate();
        }
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowInGameOption();
        }
    }

    public void ShowInGameOption()
    {
        InGameOption.SetActive(!InGameOption.activeSelf);

        if(!InGameOption.activeSelf)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void DropTower()
    {
        ClickedButton = null;

        Hover.Instance.Deactivate();
    }
}
