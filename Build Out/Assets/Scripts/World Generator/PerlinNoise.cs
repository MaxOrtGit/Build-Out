using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    int size;
    float scale;
    int offsetX;
    int offsetY;
    int seed;

    public float[,] map;

    int octaves = 3;
    float persistance = 0.5f;
    float lacunarity = 0.5f;


    public PerlinNoise(int size, float scale, float offsetX, float offsetY, int seed)
    {
        this.size = size;
        this.scale = scale;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
        this.seed = seed;

        Generate();
    }

    //generate the map using perlin noise
    public void Generate()
    {
        map = new int[size, size];

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];

        //generate the offsets
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offsetX;
            float offsetY = prng.Next(-100000, 100000) + offsetY;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        //generate the map
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                //generate the noise
                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (x - size / 2f) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y - size / 2f) / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                //set the max and min values
                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                //set the map value
                map[x, y] = (int)(noiseHeight);
            }
        }

        //normalize the values
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                map[x, y] = (int)((map[x, y] - minNoiseHeight) / (maxNoiseHeight - minNoiseHeight) * 255);
            }
        }
    }







    void GenerateBasic()
    {
        Random.Init(seed);

        seedOffsetX = Random.Range(0, 1000000);
        seedOffsetY = Random.Range(0, 1000000);
        
        map = new int[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float sample = Mathf.PerlinNoise(x / scale + offsetX + seedOffsetX, y / scale + offsetY + seedOffsetY);
                map[x, y] = (int)sample;
            }
        }
    }
    


    
}
