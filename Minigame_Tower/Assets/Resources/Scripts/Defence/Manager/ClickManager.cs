using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    InputActions inputActions;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new InputActions();
    }
    private void OnEnable()
    {
        inputActions.Defence.Enable();
        //inputActions.Defence.Click.performed += ;
        //inputActions.Defence.Click.canceled += ;
    }

    private void OnDisable()
    {
        inputActions.Defence.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnClick(InputAction.CallbackContext obj)
    //{
    //
    //}
}
