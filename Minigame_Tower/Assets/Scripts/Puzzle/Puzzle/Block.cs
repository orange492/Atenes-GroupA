using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;



public class Block : MonoBehaviour
{
    public GameObject characterPrefab;
    int indexX;
    int indexY;
    
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




 
    }

    public IEnumerator DestroyCharacter()
    {

        yield return new WaitForSeconds(0.5f);
        if (transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject); 
        }
       
    }



}
