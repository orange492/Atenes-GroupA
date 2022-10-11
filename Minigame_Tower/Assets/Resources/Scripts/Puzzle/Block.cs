using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class Block : MonoBehaviour
{
    public GameObject characterPrefab;

    private void Start()
    {
        Instantiate(characterPrefab, transform.position, transform.rotation, transform);
    }


}
