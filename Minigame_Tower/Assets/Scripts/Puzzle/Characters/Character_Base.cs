using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer sprite;
    int animalType;
    public Animator anim;
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
        sprite = transform.GetComponent<SpriteRenderer>();

        AnimalType = (int)Random.Range(0.0f, sprites.Length - 0.1f);
        sprite.sprite = sprites[AnimalType];
        anim = GetComponent<Animator>();
    }

    private void Update()
    {


    }



    public void AnimationActive(string direction)
    {

        anim.SetTrigger(direction);
    }
}