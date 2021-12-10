using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //create a 2 dimentonal dictionary that stores regions
    Dictionary<int, Dictionary<int, Region>> regions = new Dictionary<int, Dictionary<int, Region>>();

    public static int seed;
    public static bool useRandomSeed = false;


    private void Start() {
        if(useRandomSeed) {
            seed = Random.Range(0, int.MaxValue);
        }
        
    }
    


}
