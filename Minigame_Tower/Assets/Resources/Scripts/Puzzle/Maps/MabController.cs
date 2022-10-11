using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MabController : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject characterPrefab;
    public Transform blockPostionDefault;

    private void Start()
    {
        BlockCharacterCreate(6,9);
    }


    void BlockCharacterCreate(int X, int Y)
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                Vector2 position = blockPostionDefault.position + new Vector3(i * 1.25f, j * 1.25f);
                Instantiate(blockPrefab, position, transform.rotation,transform);
                Instantiate(characterPrefab, position, transform.rotation, transform);
            }
        }
    }



}
