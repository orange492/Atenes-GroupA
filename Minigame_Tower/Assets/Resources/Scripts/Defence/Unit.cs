using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    GameObject[] stars = new GameObject[5];
    public int type { get; set; }
    public int star { get; set; }
    int level;
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

    public void Init(int _type, int _star)
    {
        this.gameObject.SetActive(true);
        type = _type;
        star = _star;
        PrintUnit();
    }

    void PrintUnit()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (!stars[i].activeSelf && star > i)
            {
                stars[i].SetActive(true);
            }
            else if (stars[i].activeSelf && star <= i)
            {
                stars[i].SetActive(false);
            }
        }
    }

    public void ResetPos()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        this.gameObject.SetActive(false);
    }

    public void Merge()
    {
        star++;
        PrintUnit();
    }

    public void SetOrder(int value)
    {
        this.GetComponent<SpriteRenderer>().sortingOrder += value;
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].GetComponent<SpriteRenderer>().sortingOrder += value;
        }
    }
}
