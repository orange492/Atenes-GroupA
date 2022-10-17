using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    GameObject[] stars = new GameObject[5];
    int code;
    int level;
    int star;
    float dmg;

    // Start is called before the first frame update
    void Awake()
    {
        Transform starTr = this.transform.GetChild(0);
        for (int i = 0; i < 5; i++)
        {
            stars[i] = starTr.GetChild(i).gameObject;
            if (stars[i].activeSelf)
                stars[i].SetActive(false);
        }
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int _code, int _star)
    {
        this.gameObject.SetActive(true);
        code = _code;
        star = _star;
        PrintUnit();
    }

    void PrintUnit()
    {
        for (int i = 0; i < star; i++)
        {
            if(!stars[i].activeSelf)
                stars[i].SetActive(true);
        }
    }
}
