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
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs

=======
   IEnumerator delayIsClickLockCoroutine; 
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs

    public bool IsClickLock
    {
        get => isClickLock;
        set => isClickLock = value;
    }




    private void Awake()
    {
        inputActions = new InputActions();
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs

=======
        delayIsClickLockCoroutine = DelaySetIsClickLock();
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs


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
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs



        if (touchedObject == null) //터치한 오브젝트가 있는지 확인
=======
        StopAllCoroutines();
        StartCoroutine(DelaySetIsClickLock());

      
        if (touchedObject == null)
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
        {
            return;
        }
        if (!touchedObject.CompareTag("Block")) //터치한 오브젝트가 블록인지 확인
        {
            return;
        }
        if (touchedObject.transform.childCount == 0) //터치한 오브젝트의 자식이 있는지 확인
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



        if (dragDir.magnitude > Vector2.right.magnitude * 50) //드래그 모션인지 확인
        {
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs
            float singedAngle = Vector2.SignedAngle(Vector2.right, dragDir); //상하좌우 판별을 위한 두벡터의 사이각 구하기
=======
            float singedAngle = Vector2.SignedAngle(Vector2.right, dragDir);
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs



            if (singedAngle >= -45 && singedAngle < 45)
            {
                Debug.Log("우");
                if (touchedIndexX < blockController.blockXSize - 1 && !isMoving)
                {
                    targetIndexX += 1;
                    targetObject = blockController.blocks[targetIndexY][targetIndexX];
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs
                    if (targetObject.transform.childCount == 0)
                    {
                        return;
                    }

=======
                    if(targetObject.transform.childCount == 0)
                    {
                        return;
                    }
                   
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
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
                    StartCoroutine(ChildChange(touchedObject, targetObject));
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs
=======


                }
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
            }
        }
        else
        {
            isClickLock = false;
        }


    }


    private void OnClick(InputAction.CallbackContext obj)
    {
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs

=======
        StopAllCoroutines();
        StartCoroutine(DelaySetIsClickLock());
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
        onClickPosition = Mouse.current.position.ReadValue();
        touchedObject = null; //이전 클릭에서 저장된 오븍제트 초기화
        targetObject = null;

        if (isClickLock)
        {
            return;
        }
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs


=======
        
        isClickLock = true;
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
        if (hitInformation.collider != null)
        {

            touchedObject = hitInformation.transform.gameObject;
            Debug.Log($"{touchedObject}");

<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs
            touchedIndexX = touchedObject.transform.GetComponent<Block>().IndexX; //블록의 인덱스 찾기
            touchedIndexY = touchedObject.transform.GetComponent<Block>().IndexY; 
            targetIndexX = touchedIndexX;
=======
            touchedIndexX = touchedObject.transform.GetComponent<Block>().IndexX;
            touchedIndexY = touchedObject.transform.GetComponent<Block>().IndexY; targetIndexX = touchedIndexX;
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
            targetIndexY = touchedIndexY;




        }

    }

    IEnumerator ChildChange(GameObject touched, GameObject target)
    {
        yield return new WaitForSeconds(0.5f);
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs

        if (touched.transform.childCount == 0 ||
            target.transform.childCount == 0)
=======
        if(touched.transform.childCount==0||
        target.transform.childCount == 0)
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
        {
            yield break;
        }

        touched.transform.GetChild(0).transform.parent = transform;
        target.transform.GetChild(0).transform.parent = touched.transform;
<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs
        transform.GetChild(0).transform.parent = target.transform; 
        if (blockController.ThreeMatchCheck(touchedIndexX, touchedIndexY) ||
            blockController.ThreeMatchCheck(targetIndexX, targetIndexY))
=======
        transform.GetChild(0).transform.parent = target.transform; if (blockController.ThreeMatchCheck(touchedIndexX, touchedIndexY) ||
                        blockController.ThreeMatchCheck(targetIndexX, targetIndexY))
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
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

<<<<<<< HEAD:Minigame_Tower/Assets/Scripts/Puzzle/Core/TouchManager.cs




=======
    public IEnumerator DelaySetIsClickLock()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("DelayLock");
        IsClickLock = false;
    }
>>>>>>> parent of bede32a (블랙잭 오류수정1차):Minigame_Tower/Assets/Scripts/Puzzle/TouchManager.cs
}