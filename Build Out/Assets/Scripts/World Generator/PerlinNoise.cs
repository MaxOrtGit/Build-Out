using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerlinNoise
{
    public static float[,] Generate(int regionSize, float scale){
        float[,] map = new float[regionSize, regionSize];
        
        for(int y = 0; y < regionSize; y++){
            for(int x = 0; x < regionSize; x++){
                float locX = x / scale;
                float locY = y / scale;

                float outputVal = Mathf.PerlinNoise(locX, locY);
                map[x, y] = outputVal;
            }
        }
        return map;
    }
}
