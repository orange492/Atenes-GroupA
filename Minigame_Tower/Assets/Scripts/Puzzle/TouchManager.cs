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
    BlockController blockController;
    int touchedIndexX;
    int touchedIndexY;
    int targetIndexX;
    int targetIndexY;
    bool isMoving = false;
    bool isClickLock = false;
   IEnumerator delayIsClickLockCoroutine; 

    public bool IsClickLock
    {
        get => isClickLock;
        set => isClickLock = value;
    }




    private void Awake()
    {
        inputActions = new InputActions();
        delayIsClickLockCoroutine = DelaySetIsClickLock();


    }
    private void Start()
    {
        blockController = FindObjectOfType<BlockController>();
    }

    private void OnEnable()
    {
        inputActions.Touch.Enable();
        inputActions.Touch.Touch.performed += OnClick;
        inputActions.Touch.Touch.canceled += OffClick;
    }

    private void OnDisable()
    {
        inputActions.Touch.Touch.performed -= OnClick;
        inputActions.Touch.Touch.canceled -= OffClick;
        inputActions.Touch.Disable();
    }

    private void OffClick(InputAction.CallbackContext obj)
    {
        StopAllCoroutines();
        StartCoroutine(DelaySetIsClickLock());

      
        if (touchedObject == null)
        {
            return;
        }
        if (!touchedObject.CompareTag("Block"))
        {
            return;
        }
        if (touchedObject.transform.childCount == 0)
        {
            return;
        }
        offClickPosition = Mouse.current.position.ReadValue();
        dragDir = (offClickPosition - onClickPosition);

        Character_Base touchedCharacter = touchedObject.transform.GetChild(0).GetComponent<Character_Base>();



        if (dragDir.magnitude > Vector2.right.magnitude * 50)
        {
            float singedAngle = Vector2.SignedAngle(Vector2.right, dragDir);



            if (singedAngle >= -45 && singedAngle < 45)
            {
                Debug.Log("우");
                if (touchedIndexX < blockController.blockXSize - 1 && !isMoving)
                {
                    targetIndexX += 1;
                    targetObject = blockController.blocks[targetIndexY][targetIndexX];
                    if(targetObject.transform.childCount == 0)
                    {
                        return;
                    }
                   
                    Character_Base targetCharacter = targetObject.transform.GetChild(0).GetComponent<Character_Base>();
                    targetCharacter.AnimationActive("Left");
                    touchedCharacter.AnimationActive("Right");
                }
                else
                {
                    Debug.Log("오른쪽 이동불가");
                }
            }
            else if (singedAngle >= 45 && singedAngle < 135)
            {
                Debug.Log("상");
                if (touchedIndexY! > 0 && !isMoving)
                {
                    targetIndexY -= 1;
                    targetObject = blockController.blocks[targetIndexY][targetIndexX]; if (targetObject.transform.childCount == 0)
                    {
                        return;
                    }
                    Character_Base targetCharacter = targetObject.transform.GetChild(0).GetComponent<Character_Base>();


                    targetCharacter.AnimationActive("Down");
                    touchedCharacter.AnimationActive("Up");
                }
                else Debug.Log($"위쪽 이동불가");

            }
            else if (singedAngle >= 135 || singedAngle < -135)
            {
                Debug.Log("좌");
                if (touchedIndexX > 0 && !isMoving)
                {
                    targetIndexX -= 1;
                    targetObject = blockController.blocks[targetIndexY][targetIndexX]; if (targetObject.transform.childCount == 0)
                    {
                        return;
                    }
                    Character_Base targetCharacter = targetObject.transform.GetChild(0).GetComponent<Character_Base>();


                    targetCharacter.AnimationActive("Right");
                    touchedCharacter.AnimationActive("Left");
                }
                else
                {
                    Debug.Log("왼쪽 이동불가");
                }
            }
            else
            {
                Debug.Log("하");
                if (touchedIndexY < blockController.blockYSize - 1 && !isMoving)
                {
                    targetIndexY += 1;
                    targetObject = blockController.blocks[targetIndexY][targetIndexX]; if (targetObject.transform.childCount == 0)
                    {
                        return;
                    }
                    Character_Base targetCharacter = targetObject.transform.GetChild(0).GetComponent<Character_Base>();


                    targetCharacter.AnimationActive("Up");
                    touchedCharacter.AnimationActive("Down");
                }
                else Debug.Log("아래쪽 이동불가");
            }

            if (touchedObject != null && targetObject != null && touchedObject != targetObject)
            {
                if (!isMoving)
                {

                    StartCoroutine(ChildChange(touchedObject, targetObject));


                }
            }

        }
        else
        {
            isClickLock = false;
        }


    }


    private void OnClick(InputAction.CallbackContext obj)
    {
        StopAllCoroutines();
        StartCoroutine(DelaySetIsClickLock());
        onClickPosition = Mouse.current.position.ReadValue();
        touchedObject = null;
        targetObject = null;

        if (isClickLock)
        {
            return;
        }
        
        isClickLock = true;
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
        if (hitInformation.collider != null)
        {

            touchedObject = hitInformation.transform.gameObject;
            Debug.Log($"{touchedObject}");

            touchedIndexX = touchedObject.transform.GetComponent<Block>().IndexX;
            touchedIndexY = touchedObject.transform.GetComponent<Block>().IndexY; targetIndexX = touchedIndexX;
            targetIndexY = touchedIndexY;




        }

    }

    IEnumerator ChildChange(GameObject touched, GameObject target)
    {
        yield return new WaitForSeconds(0.5f);
        if(touched.transform.childCount==0||
        target.transform.childCount == 0)
        {
            yield break;
        }

        touched.transform.GetChild(0).transform.parent = transform;
        target.transform.GetChild(0).transform.parent = touched.transform;
        transform.GetChild(0).transform.parent = target.transform; if (blockController.ThreeMatchCheck(touchedIndexX, touchedIndexY) ||
                        blockController.ThreeMatchCheck(targetIndexX, targetIndexY))
        {
            blockController.ThreeMatchAction(touchedIndexX, touchedIndexY);
            blockController.ThreeMatchAction(targetIndexX, targetIndexY);
        }
        else
        {
            touched.transform.GetChild(0).transform.parent = transform;
            target.transform.GetChild(0).transform.parent = touched.transform;
            transform.GetChild(0).transform.parent = target.transform;
        }
    }

    public IEnumerator DelaySetIsClickLock()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("DelayLock");
        IsClickLock = false;
    }
}