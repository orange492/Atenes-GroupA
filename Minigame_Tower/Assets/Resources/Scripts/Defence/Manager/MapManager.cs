using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    GameObject[,] tile;
    [SerializeField]
    GameObject tilePref;
    [SerializeField]
    GameObject unitPref;
    int unitCnt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitMap(int x, int y)
    {
        this.transform.Translate(new Vector3(-1, -1, 0));
        tile = new GameObject[y,x];
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                tile[i, j] = Instantiate(tilePref, this.transform);
                tile[i, j].transform.Translate(j, i, 0);
                Instantiate(unitPref, tile[i, j].transform);
            }
        }
    }

    public void CrtUnit()
    {
        if(unitCnt >= tile.Length)
        {
            return;
        }

        int index;
        while (true)
        {
            index = Random.Range(0, tile.Length);
            if (!this.transform.GetChild(index).GetChild(0).gameObject.activeSelf)
                break;
        }

        Unit unit = this.transform.GetChild(index).GetChild(0).gameObject.GetComponent<Unit>();
        unit.Init(0, 1);
        unitCnt++;
    }
}
