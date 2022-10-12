using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MabController : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject characterPrefab;
    public Transform blockPostionDefault;
   public GameObject[] blocks;

 
    public int blockXSize=6;
    public int blockYSize=9;
 
   

    private void Awake()
    {
        blocks = new GameObject[blockYSize* blockXSize];
    }
    private void Start()
    {
        BlockCharacterCreate(blockXSize, blockYSize);
    }

    private void Update()
    {
       
    }


    void BlockCharacterCreate(int X, int Y)
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {

                Vector2 position = blockPostionDefault.position + new Vector3(i * 1.25f, -j * 1.25f);
                blocks[i+j*blockXSize] = Instantiate(blockPrefab, position, transform.rotation, transform);
                blocks[i + j * blockXSize].name = $"block({i},{j})";
               
                // Instantiate(characterPrefab, position, transform.rotation, transform);
            }
        }
    }



}
