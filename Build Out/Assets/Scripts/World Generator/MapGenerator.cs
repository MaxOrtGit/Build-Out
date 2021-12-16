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

    public float[,] map;

    public int octaves = 3;
    public float persistance = 0.5f;
    public float lacunarity = 0.5f;

    public Renderer textureRender;


    private void Start() {

        float[,] noiseMap = PerlinNoise.Generate(size, scale);
        DrawNoiseMap(noiseMap);
        


    }


    public void DrawNoiseMap(float[,] noiseMap){
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        Color[] colorMap = new Color[width * height];
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }
        texture.SetPixels(colorMap);
        texture.Apply();

        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(width, 1, height);

        
    }

    

    


}
