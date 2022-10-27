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
        
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        sprite.sprite = sprites[AnimalType];
    }
    private void Update()
    {


    }



    public void AnimationActive(string direction)
    {

        anim.SetTrigger(direction);
    }
}