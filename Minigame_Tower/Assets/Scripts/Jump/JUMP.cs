using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Diagnostics;

public class JUMP : MonoBehaviour
{
    public float JumpPower = 300.0f;
    [SerializeField] private LayerMask platformLayerMask;
    BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        IsGrounded();
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (IsGrounded() == true)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));
            }
        }
    }

    public bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeight, platformLayerMask);
        //RaycastHit 검사, 검사 시작 위치: boxCollider2D center, 검사 방향: Down
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        UnityEngine.Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        UnityEngine.Debug.Log(raycastHit.collider);

        if (raycastHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}