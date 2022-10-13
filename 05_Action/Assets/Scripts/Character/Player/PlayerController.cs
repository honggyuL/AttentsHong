using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    public float moveDir = 0.0f;
    private Vector3 currentDirection = Vector3.zero;

    Rigidbody rigid;
    PlayerInputActions inputActions;

    Animator anim;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }


    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector3 input = context.ReadValue<Vector3>();
        moveDir = input.y;
        
    }

    

    
}
