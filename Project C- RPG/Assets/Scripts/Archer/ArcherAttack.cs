using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArcherAttack : MonoBehaviour
{
    public float AngleRange = 120f;
    public float distance = 15.0f;

    PlayerInputActions inputActions;
    Animator anim;
    internal GameObject myTarget;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Attack.performed += OnAttack;
        
    }

    private void OnDisable()
    {
        
        inputActions.Player.Attack.performed -= OnAttack;
        inputActions.Player.Disable();
    }

    

    private void OnAttack(InputAction.CallbackContext _)
    {
        anim.SetTrigger("Attack");
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, AngleRange / 2, distance);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -AngleRange / 2, distance);
    }

    public void DrawArrow()
    {
        GameObject go;
    }
}
