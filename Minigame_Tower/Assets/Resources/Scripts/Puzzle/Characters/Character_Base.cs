using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer sprite;
    int random;
    public Animator anim;
    UnityEngine.Vector3 targetDir;

    private void Awake()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        random = (int)Random.Range(0.0f, sprites.Length-0.1f);
        sprite.sprite = sprites[random];
        anim = GetComponent<Animator>();

    }

    private void Start()
    {
        StartCoroutine(RefreshPosition());
    }

    private void Update()
    {
        //if(transform.position != transform.parent.position)
        //{
        //    ActiveAnimation();
        //}
    }

    IEnumerator RefreshPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            transform.position = transform.parent.position;
        }
    }

    //void ActiveAnimation()
    //{
    //    targetDir = transform.parent.position - transform.position;
    //    if (targetDir.x > 0.5)
    //    {
    //        anim.SetTrigger("Right");
    //    }
    //    if(targetDir.x < -0.5)
    //        anim.SetTrigger("Left");
    //    if(targetDir.y>0.5)
    //        anim.SetTrigger("Up");
    //    if(targetDir.y<-0.5)
    //        anim.SetTrigger("Down");
    //}
}
