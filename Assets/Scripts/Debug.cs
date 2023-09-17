using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{
    [SerializeField]
    private TileScripts start;

    [SerializeField]
    private TileScripts goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
            ClickTile();  

        if(Input.GetKeyDown(KeyCode.Space))
        {
            PathFind.GetPath(start.GridPosition);
        }
    }

    private void ClickTile()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                TileScripts tmp = hit.collider.GetComponent<TileScripts>();

                if (tmp != null)
                {
                    if (start == null)
                    {
                        start = tmp;

                        start.SpriteRenderer.color = new Color(255, 132, 0, 255);

                        start.Debug = true;
                    }
                    else if(goal == null)
                    {
                        goal = tmp;

                        goal.SpriteRenderer.color = new Color(255, 0, 0, 255);

                        goal.Debug = true;
                    }
                }
            }
        }
    }

    public void DebugPath(HashSet<Node> openList)
    {
        foreach(Node node in openList)
        {
            node.TileRef.SpriteRenderer.color = Color.cyan;
        }
    }
}
