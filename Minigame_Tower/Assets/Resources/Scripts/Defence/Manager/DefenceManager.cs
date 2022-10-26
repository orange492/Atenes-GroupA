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
        mapMgr.InitMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetUnitCnt(int value)
    {
        mapMgr.unitCnt += value;
    }
}
