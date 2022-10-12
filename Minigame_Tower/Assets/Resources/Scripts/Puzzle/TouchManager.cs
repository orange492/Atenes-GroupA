using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    InputActions inputActions;
    Vector2 onClickPosition;
    Vector2 offClickPosition;
    Vector2 dragDir;
    GameObject touchedObject;
    GameObject targetObject;
    MabController mabController;
    int index;




    private void Awake()
    {
        inputActions = new InputActions();

    }
    private void Start()
    {
        mabController = FindObjectOfType<MabController>();
    }

    private void OnEnable()
    {
        inputActions.Touch.Enable();
        inputActions.Touch.Touch.performed += OnClick;
        inputActions.Touch.Touch.canceled += OffClick;
    }

    private void OnDisable()
    {
        inputActions.Touch.Disable();
    }

    private void OffClick(InputAction.CallbackContext obj)
    {
        offClickPosition = Mouse.current.position.ReadValue();
        dragDir = (offClickPosition - onClickPosition);





        if (dragDir.magnitude > Vector2.right.magnitude * 50)
        {
            float singedAngle = Vector2.SignedAngle(Vector2.right, dragDir);

            if (singedAngle >= -45 && singedAngle < 45)
            {
                Debug.Log("우");
                if (index % mabController.blockXSize != 5)
                    targetObject = mabController.blocks[index + 1];
                else
                {
                    Debug.Log("오른쪽 이동불가");
                }
            }
            else if (singedAngle >= 45 && singedAngle < 135)
            {
                Debug.Log("상");
                if (index >= mabController.blockXSize)
                {
                    targetObject = mabController.blocks[index - mabController.blockXSize];
                
                }
                else
                    Debug.Log($"위쪽 이동불가{index}");

            }
            else if (singedAngle >= 135 || singedAngle < -135)
            {
                Debug.Log("좌");
                if (index != 0 && index % mabController.blockXSize != 0)
                    targetObject = mabController.blocks[index - 1];
                else
                {
                    Debug.Log("왼쪽 이동불가");
                }
            }
            else
            {
                Debug.Log("하");
                if (index <= mabController.blockXSize * (mabController.blockYSize - 1) - 1)
                    targetObject = mabController.blocks[index + mabController.blockXSize];
                else
                    Debug.Log("아래쪽 이동불가");
            }

            if (touchedObject != null && targetObject != null && touchedObject != targetObject)
            {
                touchedObject.transform.GetChild(0).transform.parent = transform;
                targetObject.transform.GetChild(0).transform.parent = touchedObject.transform;
                transform.GetChild(0).transform.parent = targetObject.transform;
                
            }


        }

    }

    private void OnClick(InputAction.CallbackContext obj)
    {
        onClickPosition = Mouse.current.position.ReadValue();
        touchedObject = null;
        targetObject = null;

        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
        if (hitInformation.collider != null)
        {

            touchedObject = hitInformation.transform.gameObject;
            Debug.Log($"{touchedObject}");
            index = Array.IndexOf(mabController.blocks, touchedObject);

        }
   
    }
}
