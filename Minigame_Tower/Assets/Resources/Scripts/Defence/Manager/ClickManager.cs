using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    InputActions inputActions;
    GameObject[] clickUnit = new GameObject[2];
    Unit[] unit = new Unit[2];
    Vector2 touchPos;
    bool isClick = false;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new InputActions();
    }
    private void OnEnable()
    {
        inputActions.Defence.Enable();
        inputActions.Defence.Click.performed += OnClick;
        inputActions.Defence.Click.canceled += OffClick;
    }

    private void OnDisable()
    {
        inputActions.Defence.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            clickUnit[0].transform.position = touchPos;
        }
    }

    private void OnClick(InputAction.CallbackContext obj)
    {
        touchPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
        if (hitInformation.collider != null)
        {
            clickUnit[0] = hitInformation.transform.gameObject;
            unit[0] = clickUnit[0].GetComponent<Unit>();
            unit[0].SetOrder(1);
            isClick = true;
        }

    }
    private void OffClick(InputAction.CallbackContext obj)
    {
        if (!isClick)
        {
            return;
        }
        unit[0].SetOrder(-1);
        unit[0].ResetPos();
        touchPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
        if (hitInformation.collider != null)
        {
            clickUnit[1] = hitInformation.transform.gameObject;
            unit[1] = clickUnit[1].GetComponent<Unit>();
            if (unit[0].type == unit[1].type && unit[0].star == unit[1].star && unit[0].star < 6)
            {
                unit[1].Merge();
                DefenceManager.Instance.SetUnitCnt(-1);
            }
            else
            {
                clickUnit[0].SetActive(true);
            }
        }
        else
        {
            clickUnit[0].SetActive(true);
        }
        for (int i = 0; i < 2; i++)
        {
            clickUnit[i] = null;
            unit[i] = null;
        }
        isClick = false;
    }
}
