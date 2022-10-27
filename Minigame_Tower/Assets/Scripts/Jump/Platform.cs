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

    IEnumerator Moveoverthereinafewseconds(Vector2 TargetPosition, float TargetTime)
    {
        float ElapsedTime = 0.0f;
        Vector2 FirstPosition = transform.position;
        while (ElapsedTime < TargetTime)
        {
            Vector2 new_pos = Vector2.Lerp(FirstPosition, TargetPosition, ElapsedTime / TargetTime);
            transform.position = new_pos;
            ElapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Arrive();
    }

    public void Arrive()
    {
        move_dir *= -1.0f;
        StartCoroutine(Moveoverthereinafewseconds((Vector2)transform.position + move_dir * distance, move_time));
    }
}
