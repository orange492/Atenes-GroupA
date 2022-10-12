using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    public GameObject characterPrefab;

    private void Start()
    {
        Instantiate(characterPrefab, transform.position, transform.rotation, transform);
    }


}
