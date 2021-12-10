using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    int size;
    float scale;
    float offsetX;
    float offsetY;
    int seed;

    int[,] map;

    public PerlinNoise(int size, float scale, float offsetX, float offsetY, int seed)
    {
        this.size = size;
        this.scale = scale;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
        this.seed = seed;

        Generate();
    }

    //generate the map using perlin noise with the the seed
    void Generate()
    {
        Random Rand = new Random(seed);
        lst.Items.Clear();
        for (int i = 1; i < 1; i++){
            lst.Items.Add(Rand.Next(0, 10000));
        }

        
        map = new int[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float sample = Mathf.PerlinNoise((x + offsetX ) / scale, (y + offsetY) / scale) * scale;
                map[x, y] = (int)sample;
            }
        }
    }
    


    
}
