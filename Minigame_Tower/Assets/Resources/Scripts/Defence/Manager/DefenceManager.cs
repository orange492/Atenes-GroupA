using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceManager : Singleton<DefenceManager>
{
    [SerializeField]
    GameObject oLife;

    MapManager mapMgr;
    EnemySpawner enemySpnr;

    int life;

    // Start is called before the first frame update
    void Start()
    {
        mapMgr = FindObjectOfType<MapManager>();
        enemySpnr = FindObjectOfType<EnemySpawner>();
        mapMgr.InitMap();
        enemySpnr.CrtEnemy();

        life = 3;
        SetLife(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetUnitCnt(int value)
    {
        mapMgr.unitCnt += value;
    }

    public void SetLife(int value)
    {
        if (life + value >= 0 && life + value < 4)
        {
            life += value;
        }
        for (int i = 0; i < oLife.transform.childCount; i++)
        {
            if (!oLife.transform.GetChild(i).gameObject.activeSelf && life > i)
            {
                oLife.transform.GetChild(i).gameObject.SetActive(true);
            }
            else if (oLife.transform.GetChild(i).gameObject.activeSelf && life <= i)
            {
                oLife.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
