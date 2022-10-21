using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class WarriorAttack : MonoBehaviour
{
    public float AngleRange = 120.0f;
    public float distance = 50.0f;
    

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
        inputActions.Player.Attack.performed += OnAttack;
    }

    private void OnDisable()
    {
        inputActions.Player.Attack.canceled -= OnAttack;
        inputActions.Player.Disable();
    }

    private void OnAttack(InputAction.CallbackContext _)
    {
        int combo = anim.GetInteger("Combo"); // ComboState를 애니메이터에서 읽어와서 
        combo++;   // 콤보 상태 1 증가 시키기        
        anim.SetInteger("Combo", combo);      // 애니메이터에 증가된 콤보 상태 설정
        anim.SetTrigger("Attack");
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        // 부채꼴모양으로 확인하기
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, AngleRange / 2, distance);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -AngleRange / 2, distance);
    }

    public void OnclickAttackButton()
    {
        if(anim.GetBool("IsAttack") = false)
        {

        }
    }
}
