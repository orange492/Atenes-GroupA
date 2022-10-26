using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int[] mapSize { get; set; }

    // Start is called before the first frame update
    public void Awake()
    {
        mapSize = new int[2];
        mapSize[0] = 5;
        mapSize[1] = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
