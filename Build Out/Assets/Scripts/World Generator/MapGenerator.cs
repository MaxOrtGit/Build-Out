using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //create a 2 dimentonal dictionary that stores regions
    Dictionary<int, Dictionary<int, Region>> regions = new Dictionary<int, Dictionary<int, Region>>();

    public static int seed;
    public static bool useRandomSeed = false;

    public int size = 256;
    public float scale = 20f;
    public int offsetX = 0;
    public int offsetY = 0;
    public int seed;

    public float[,] map;

    public int octaves = 3;
    public float persistance = 0.5f;
    public float lacunarity = 0.5f;


    private void Start() {
        if(useRandomSeed) {
            seed = Random.Range(0, int.MaxValue);
        }
        PerlinNoise noise = new PerlinNoise(size, scale, offsetX, offsetY, seed);

        //


    }

    Color CalculateColor(int )
    


}
