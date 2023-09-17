using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Point GridPosition { get; private set; }

    public TileScripts TileRef { get; private set;}

    public Node(TileScripts tileRef)
    {
        this.TileRef = tileRef;

        this.GridPosition = tileRef.GridPosition;
    }
}
