using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    static int regionSize = 8;

    //create a 2d array of the tiles in a region with the size of regionSize
    public Tile[,] tiles = new Tile[regionSize, regionSize];

    Vector2Int regionLocation;
    
}
