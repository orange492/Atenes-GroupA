using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Playables;

public class Character_Base : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    int animalType;
    Animator anim;
    UnityEngine.Vector3 targetDir;





    ParticleSystem ps;
    public int AnimalType
    {
        get => animalType;
        set
        {
            animalType = value;
        }
    }

    enum Animal
    {
        Bear,
        Cat,
        Deer,
        Dog,
        Duck
        //Mouse,
        //Panda,
        // Pig,
        //Rabbit
    }




    private void Awake()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();



        anim = GetComponent<Animator>();

    }

    private void Start()
    {


    }
    private void Update()
    {


    }




    public void AnimationActive(string direction)
    {

        anim.SetTrigger(direction);
    }

    public void Init(int type, Sprite spr)
    {
        animalType = type;
        spriteRenderer.sprite = spr;
    }
}