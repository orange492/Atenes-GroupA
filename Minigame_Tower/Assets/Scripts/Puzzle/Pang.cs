using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Pang : MonoBehaviour
{
    Animator anim;
    Block block;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        block = transform.GetComponentInParent<Block>();
    }

    public void DestroyCharacter()
    {
        block.DestroyCharacter();
    }



}
