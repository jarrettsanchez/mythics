using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScripts : MonoBehaviour
{
    public Point GridPosition { get;private set; }

    public bool IsEmpty { get; private set; }

    private Color32 fullColor = new Color32(255, 118, 118, 255);

    private Color32 emptyColor = new Color32(96, 255, 90, 255);

    public SpriteRenderer SpriteRenderer { get; set; }

    public bool Debug { get; set; }

    public Vector2 WorldPosition
    {
        get 
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

        if (GetComponent<SpriteRenderer>().sprite.name != "grass_02")
        {
            IsEmpty = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Point gridPosition, Vector3 worldPos,Transform parent)
    {
        IsEmpty = true;

        this.GridPosition = gridPosition;

        transform.position = worldPos;

        LevelManager.Instance.Tiles.Add(gridPosition, this);

        transform.SetParent(parent);
    }

    private void OnMouseOver()
    {
        if (Time.timeScale != 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedButton != null)
            {
                if (IsEmpty && !Debug)
                {
                   ColorTile(emptyColor);
                 }
                if(!IsEmpty && !Debug)
                {
                   ColorTile(fullColor);
                }
                else if (Input.GetMouseButtonDown(0))
                {
                   PlaceTower();
                }
             }
        }
    }

    private void OnMouseExit()
    {
        if (!Debug)
        {
            ColorTile(Color.white);
        }  
    }

    private void PlaceTower()
    {
        if (Time.timeScale != 0)
        {
            GameObject tower = (GameObject)Instantiate(GameManager.Instance.ClickedButton.TowerPrefab, transform.position, Quaternion.identity);

            tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;

            tower.transform.SetParent(transform);

            IsEmpty = false;

            ColorTile(Color.white);

            GameManager.Instance.BuyTower();
        }
        
    }

    private void ColorTile(Color newColor)
    {
        SpriteRenderer.color = newColor;
    }
}
