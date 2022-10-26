using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class BlockController : MonoBehaviour
{
    public GameObject blockPrefab;
    public Transform blockPostionDefault;
    public GameObject[][] blocks;


    public int blockXSize = 6;
    public int blockYSize = 9;



    private void Awake()
    {
        blocks = new GameObject[blockYSize][];
        for (int i = 0; i < blockYSize; i++)
        {
            blocks[i] = new GameObject[blockXSize];
        }
        
    }
    private void Start()
    {
        BlockCharacterCreate(blockXSize, blockYSize);

        //for (int i = 0; i < blockXSize; i++)
        //{
        //    for (int j = 0; j < blockYSize; j++)
        //    {
        //        ThreeMatchCheck(i, j);

        //    }
        //}


    }




    void BlockCharacterCreate(int X, int Y)
    {
        for (int j = 0; j < Y; j++)
        {
            for (int i = 0; i < X; i++)
            {

                Vector2 position = blockPostionDefault.position + new Vector3(i * 1.25f, -j * 1.25f);
                blocks[j][i] = Instantiate(blockPrefab, position, transform.rotation, transform);
                blocks[j][i].name = $"block({i},{j})";
                Block block = blocks[j][i].GetComponent<Block>();
                block.IndexX = i;
                block.IndexY = j;

                // Instantiate(characterPrefab, position, transform.rotation, transform);
            }
        }
    }

    public bool ThreeMatchCheck(int X, int Y)
    {

      
        
         int   animalType = blocks[Y][X].transform.GetComponentInChildren<Character_Base>().AnimalType;
       

        XThreeMatchCheck(X, Y, animalType);

       

        YThreeMatchCheck(X, Y, animalType);

        
        bool isThreeMactch = XThreeMatchCheck( X, Y,animalType);
        isThreeMactch = YThreeMatchCheck( X, Y,animalType);
    
        isThreeMactch = false;
        
        return (XThreeMatchCheck(X, Y, animalType)||

       

        YThreeMatchCheck(X, Y, animalType)

   
           );


    }


  public  bool XThreeMatchCheck(int X, int Y, int animalType)
    {
        Character_Base[] characters;
        characters = new Character_Base[2];
        bool isThreeMatch = false;
        if (X + 2 < blockXSize)
        {
            characters[0] = blocks[Y][X + 1].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y][X + 2].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    isThreeMatch = true;
                    for (int i = 0; i < 3; i++)
                    {
                        blocks[Y][X+i].transform.GetComponent<Block>().IsThreeMatch = isThreeMatch;
                    }
                    
                    for (int i = 0; i < 2; i++)
                    {
                        
                        characters[i] = null;
                    }
                    
                }
            }
        }

            if (X + 1 < blockXSize && X - 1 >= 0)
            {
                characters[0] = blocks[Y][X - 1].GetComponentInChildren<Character_Base>();
                characters[1] = blocks[Y][X + 1].GetComponentInChildren<Character_Base>();
                if (characters[0] != null && characters[1] != null)
                {
                    if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                    {
                    isThreeMatch = true;
                    for (int i = 0; i < 3; i++)
                    {
                        blocks[Y][X + i-1].transform.GetComponent<Block>().IsThreeMatch = isThreeMatch;
                    }
                    for (int i = 0; i < 2; i++)
                        {
                            characters[i] = null;
                        }
                        
                    }
                }
            }
            if (X - 2 >= 0)
            {
                characters[0] = blocks[Y][X - 1].GetComponentInChildren<Character_Base>();
                characters[1] = blocks[Y][X - 2].GetComponentInChildren<Character_Base>();
                if (characters[0] != null && characters[1] != null)
                {
                    if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                    {
                    isThreeMatch = true;
                    for (int i = 0; i < 3; i++)
                    {
                        blocks[Y][X + i-2].transform.GetComponent<Block>().IsThreeMatch = isThreeMatch;
                    }
                    for (int i = 0; i < 2; i++)
                        {
                            characters[i] = null;
                        }
                        
                    }
                }

                
            }
            return isThreeMatch;
        }
  public  bool YThreeMatchCheck(int X, int Y, int animalType)
    {
        Character_Base[] characters;
        characters = new Character_Base[2];
        bool isThreeMatch = false;
        if (Y + 2 < blockYSize)
        {
            characters[0] = blocks[Y+1][X ].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y+2][X ].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    isThreeMatch = true;
                    for (int i = 0; i < 3; i++)
                    {
                        blocks[Y+i][X].transform.GetComponent<Block>().IsThreeMatch = isThreeMatch;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        characters[i] = null;
                    }
                    
                }
            }
        }

        if (Y + 1 < blockYSize && Y - 1 >= 0)
        {
            characters[0] = blocks[Y - 1][X].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y+1][X ].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    isThreeMatch = true;
                    for (int i = 0; i < 3; i++)
                    {
                        blocks[Y + i-1][X].transform.GetComponent<Block>().IsThreeMatch = isThreeMatch;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        characters[i] = null;
                    }
                    
                }
            }
        }
        if (Y - 2 >= 0)
        {
            characters[0] = blocks[Y-1][X ].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y-2][X ].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    isThreeMatch = true;
                    for (int i = 0; i < 3; i++)
                    {
                        blocks[Y + i-2][X].transform.GetComponent<Block>().IsThreeMatch = isThreeMatch;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        characters[i] = null;
                    }
                    
                }
            }


        }
        return isThreeMatch;
    }


    void FindChar(int X, int Y, Character_Base character_Base)
    {
        character_Base = blocks[Y][X].GetComponentInChildren<Character_Base>();
    }





}
