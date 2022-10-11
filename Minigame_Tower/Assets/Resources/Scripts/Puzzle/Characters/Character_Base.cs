using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer sprite;
    int random;

    private void Awake()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        random = (int)Random.Range(0.0f, sprites.Length);
        sprite.sprite = sprites[random];
    }
}
