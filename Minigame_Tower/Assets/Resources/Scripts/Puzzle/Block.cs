using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    public GameObject characterPrefab;
    int indexX;
    int indexY;
    bool isThreeMatch = false;
    public int IndexX
    {
        get => indexX;
        set
        {
            indexX = value;
        }
    }
    public int IndexY
    {
        get => indexY;
        set
        {
            indexY = value;
        }
    }
    int animalType;
    public int AnimalType
    {
        get => animalType;
        set
        {
            animalType = value;
        }
    }

    public bool IsThreeMatch
    {
        get => isThreeMatch;
        set
        {
            isThreeMatch = value;
        }

    }

    private void Start()
    {
        Instantiate(characterPrefab, transform.position, transform.rotation, transform);


    }
    private void Update()
    {
        if (transform.childCount == 0)
        {
            //Instantiate(characterPrefab, transform.position, transform.rotation, transform);
        }
        //if (isThreeMatch)
        //{
        //    transform.GetChild(0).gameObject.SetActive(false);
        //}
        //if (!transform.GetChild(0).gameObject.activeSelf)
        //{
        //    transform.GetComponentInChildren<Character_Base>().AnimalType
        //}
    }



}
