using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceManager : Singleton<DefenceManager>
{
    MapManager mapMgr;
    // Start is called before the first frame update
    void Start()
    {
        mapMgr = FindObjectOfType<MapManager>();
        mapMgr.InitMap(DataManager.Instance.map[0], DataManager.Instance.map[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
