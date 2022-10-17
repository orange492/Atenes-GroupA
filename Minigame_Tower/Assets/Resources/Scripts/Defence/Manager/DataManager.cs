using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int[] map { get; set; }

    // Start is called before the first frame update
    public void Awake()
    {
        map = new int[2];
        map[0] = 3;
        map[1] = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
