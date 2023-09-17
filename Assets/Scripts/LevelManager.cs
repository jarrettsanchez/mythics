using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    [SerializeField]
    private Transform map;

    public Dictionary<Point,TileScripts> Tiles { get; set; }

    private Point blueSpawn;

    private Point redSpawn;

    [SerializeField]
    private GameObject bluePortalPrefab;

    [SerializeField]
    private GameObject redPortalPrefab;

    public static LevelManager main;//ce shi//

    public Transform startPoint;//ce shi//
    public Transform[] path;//ce shi//

    private void Awake()
    {
        main = this;
    }//ce shi//

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScripts>();

        string[] mapData = ReadLevelText();

        int mapXSize = mapData[0].ToCharArray().Length;

        int mapYSize = mapData.Length;

        Camera mainCamera = Camera.main;

        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenAspect;

        Vector3 worldStart = mainCamera.transform.position - new Vector3(cameraWidth / 2f, -cameraHeight / 2f, 0f);

        for (int y = 0; y < mapYSize; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapXSize; x++)
            {
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);
            }
        }

        SpawnPortals();
    }



    private void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);
    
        TileScripts newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScripts>();

        float tileSize = TileSize;

        newTile.Setup(new Point(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0),map);
    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;

        string data = bindData.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');
    }

    private void SpawnPortals()
    {
        blueSpawn = new Point(0, 0);

        Instantiate(bluePortalPrefab, Tiles[blueSpawn].GetComponent<TileScripts>().WorldPosition, Quaternion.identity);

        redSpawn = new Point(12, 0);

        Instantiate(redPortalPrefab, Tiles[redSpawn].GetComponent<TileScripts>().WorldPosition, Quaternion.identity);
    }


    private void MoveEneny()
    {
        
    }

}
