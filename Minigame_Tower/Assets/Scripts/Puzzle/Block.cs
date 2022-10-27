using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    public GameObject characterPrefab;
    int indexX;
    int indexY;
    public Sprite[] sprites;
    Animator pangAnim;
   
 
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
        pangAnim = transform.GetChild(0).GetComponent<Animator>();
        blockController = FindObjectOfType<BlockController>();
        MakeCharacter();

       

    }
    private void Update()
    {
        
        if (transform.childCount == 1 && indexY == 0)
        {

            MakeCharacter();
            blockController.StartCoroutine(blockController.CharacterDown());

        }

    }


    void MakeCharacter()
    {
        GameObject obj = Instantiate(characterPrefab, transform.position, transform.rotation, transform);

        Character_Base character_Base = obj.GetComponent<Character_Base>();
        int animalType = Random.Range(0, sprites.Length);

        character_Base.Init(animalType, sprites[animalType]);
    }

    public void PangAnimationActive()
    {
        pangAnim.SetTrigger("Pang");
    }

    public void DestroyCharacter()
    {
        if (transform.childCount != 1)
        {
            Destroy(transform.GetChild(1).gameObject);
            
        }

    }



}
