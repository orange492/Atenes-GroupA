using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;



public class Block : MonoBehaviour
{
    public GameObject characterPrefab;
    int indexX;
    int indexY;
    bool isThreeMatch = false;
    BlockController blockController;


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
        blockController = FindObjectOfType<BlockController>();

    }
    private void Update()
    {
       
            if (transform.childCount == 0 && indexY == 0)
            {
              
                Instantiate(characterPrefab, transform.position, transform.rotation, transform);
                blockController.StartCoroutine(blockController.CharacterDown());



            }
        
        if (isThreeMatch)
        {

            StartCoroutine(DestroyCharacter());

        }
        else
        {
            StopAllCoroutines();
        }


        //{
        //    transform.GetChild(0).gameObject.SetActive(false);
        //}
        //if (!transform.GetChild(0).gameObject.activeSelf)
        //{
        //    transform.GetComponentInChildren<Character_Base>().AnimalType
        //}
    }

    IEnumerator DestroyCharacter()
    {

        yield return new WaitForSeconds(0.5f);
        if (transform.childCount != 0)
            Destroy(transform.GetChild(0).gameObject);
        isThreeMatch = false;
    }



}
