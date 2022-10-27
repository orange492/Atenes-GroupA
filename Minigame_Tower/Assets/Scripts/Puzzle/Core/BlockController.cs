using JetBrains.Annotations;
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
    TouchManager touchManager;

    public int blockXSize = 6;
    public int blockYSize = 9;
    private float TimeLeft = 0.5f;
    private float nextTime = 0.0f;



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

        touchManager = FindObjectOfType<TouchManager>();
        //for (int i = 0; i < blockXSize; i++)
        //{
        //    for (int j = 0; j < blockYSize; j++)
        //    {
        //        ThreeMatchCheck(i, j);

        //    }
        //}
        if (AllBlockCheck())
        {
            AllBlockAction();
        }


    }

    private void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;


            if (AllBlockCheck() && BlockFullcheck())
            {
                AllBlockAction();

            }



        }

    }

    bool BlockFullcheck()
    {
        for (int i = 0; i < blockXSize; i++)
        {
            for (int j = 0; j < blockYSize; j++)
            {
                if (blocks[j][i].transform.childCount == 1)
                {
                    return false;
                }

            }
        }
        return true;
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

    bool AllBlockCheck()
    {
        for (int i = 0; i < blockXSize; i++)
        {
            for (int j = 0; j < blockYSize; j++)
            {
                if (ThreeMatchCheck(i, j))
                    return true;

            }
        }
        return false;
    }

    void AllBlockAction()
    {
        for (int i = 0; i < blockXSize; i++)
        {
            for (int j = 0; j < blockYSize; j++)
            {
                ThreeMatchAction(i, j);

            }
        }
    }

    public bool ThreeMatchCheck(int X, int Y)
    {

        int animalType = -1;
        Character_Base character_Base = blocks[Y][X].transform.GetComponentInChildren<Character_Base>();
        if (character_Base != null)
        {
            animalType = character_Base.AnimalType;
        }

        XThreeMatchCheck(X, Y, animalType);




        YThreeMatchCheck(X, Y, animalType); 
        //touchManager.StartCoroutine(touchManager.DelaySetIsClickLock());

        return (XThreeMatchCheck(X, Y, animalType) ||




        YThreeMatchCheck(X, Y, animalType)



           );


    }

    public void ThreeMatchAction(int X, int Y)
    {

        int animalType = -1;
        Character_Base character_Base = blocks[Y][X].transform.GetComponentInChildren<Character_Base>();
        if (character_Base != null)
        {
            animalType = character_Base.AnimalType;
        }

        XThreeMatchAction(X, Y, animalType);
        YThreeMatchAction(X, Y, animalType);
        for (int i = 0; i < blockYSize; i++)
        {
            StartCoroutine(CharacterDown());

        }
        return;

    }

    bool XThreeMatchCheck(int X, int Y, int animalType)
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


                }
                for (int i = 0; i < 2; i++)
                {
                    characters[i] = null;
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

                    if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                    { isThreeMatch = true; }
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
                }
                for (int i = 0; i < 2; i++)
                {
                    characters[i] = null;
                }
            }
        }

        return isThreeMatch;
    }

    void XThreeMatchAction(int X, int Y, int animalType)
    {
        Character_Base[] characters;
        characters = new Character_Base[4];

        if (X + 2 < blockXSize)
        {
            characters[0] = blocks[Y][X + 1].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y][X + 2].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    for (int i = 0; i < 3; i++)
                    {

                        CharacterDestroyAndAnimation(X + i, Y);
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
                    for (int i = 0; i < 3; i++)
                    {
                        CharacterDestroyAndAnimation(X + i - 1, Y);
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
                    for (int i = 0; i < 3; i++)
                    {
                        CharacterDestroyAndAnimation(X + i -2, Y);
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        characters[i] = null;
                    }

                }
            }
        }
        return;
    }


    bool YThreeMatchCheck(int X, int Y, int animalType)
    {
        Character_Base[] characters;
        characters = new Character_Base[2];
        bool isThreeMatch = false;
        if (Y + 2 < blockYSize)
        {
            characters[0] = blocks[Y + 1][X].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y + 2][X].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    isThreeMatch = true;
                }
                for (int i = 0; i < 2; i++)
                {
                    characters[i] = null;
                }
            }
        }

        if (Y + 1 < blockYSize && Y - 1 >= 0)
        {
            characters[0] = blocks[Y - 1][X].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y + 1][X].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    isThreeMatch = true;

                }
                for (int i = 0; i < 2; i++)
                {
                    characters[i] = null;
                }

            }
        }
        if (Y - 2 >= 0)
        {
            characters[0] = blocks[Y - 1][X].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y - 2][X].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    isThreeMatch = true;



                }
                for (int i = 0; i < 2; i++)
                {
                    characters[i] = null;
                }
            }


        }
        return isThreeMatch;
    }
    public void YThreeMatchAction(int X, int Y, int animalType)
    {
        Character_Base[] characters;
        characters = new Character_Base[2];

        if (Y + 2 < blockYSize)
        {
            characters[0] = blocks[Y + 1][X].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y + 2][X].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        CharacterDestroyAndAnimation(X , Y+i);
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
            characters[1] = blocks[Y + 1][X].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        CharacterDestroyAndAnimation(X, Y+i-1);
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
            characters[0] = blocks[Y - 1][X].GetComponentInChildren<Character_Base>();
            characters[1] = blocks[Y - 2][X].GetComponentInChildren<Character_Base>();
            if (characters[0] != null && characters[1] != null)
            {
                if ((animalType == characters[0].AnimalType) && animalType == characters[1].AnimalType)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        CharacterDestroyAndAnimation(X, Y + i -2);
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        characters[i] = null;
                    }


                }
            }


        }
        return;
    }
    public IEnumerator CharacterDown()
    {

        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < blockXSize; i++)
        {
            for (int j = 0; j < blockYSize - 1; j++)
            {
                if (blocks[j][i].transform.childCount == 2 && blocks[j + 1][i].transform.childCount == 1)
                {
                    blocks[j][i].transform.GetChild(1).transform.parent = blocks[j + 1][i].transform;
                }
            }

        }

    }

    void CharacterDestroyAndAnimation(int X, int Y)
    {
        Block block = blocks[Y][X].transform.GetComponent<Block>();
        block.PangAnimationActive();
        
    }




}