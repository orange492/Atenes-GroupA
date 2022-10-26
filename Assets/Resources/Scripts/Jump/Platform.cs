using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector2 move_dir = Vector2.right;
    public float distance = 2.0f;
    public float move_time = 4.0f;
    public void Start()
    {
        StartCoroutine(Moveoverthereinafewseconds((Vector2)transform.position + move_dir * distance, move_time));
    }

    IEnumerator Moveoverthereinafewseconds(Vector2 targetposition, float targettime)
    {
        float elapsedtime = 0.0f;
        Vector2 firstposition = transform.position;
        while (elapsedtime < targettime)
        {
            Vector2 new_pos = Vector2.Lerp(firstposition, targetposition, elapsedtime / targettime);
            transform.position = new_pos;
            elapsedtime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        arrive();
    }

    public void arrive()
    {
        move_dir *= -1.0f;
        StartCoroutine(Moveoverthereinafewseconds((Vector2)transform.position + move_dir * distance, move_time));
    }
}

