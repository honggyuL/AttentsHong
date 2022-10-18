using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArcherAttack : MonoBehaviour
{
    PlayerInputActions inputActions;
    Animator anim;
    public GameObject ArrowPrefab;
    

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Attack.performed += OnAttack;
        inputActions.Player.Attack.canceled += OnAttack;
    }

    private void OnDisable()
    {
        inputActions.Player.Attack.canceled -= OnAttack;
        inputActions.Player.Attack.performed -= OnAttack;
        inputActions.Player.Disable();
    }


    private void OnAttack(InputAction.CallbackContext _)
    {
        
    }
}
