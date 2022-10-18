using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Warrior : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 30.0f;

    int groundLayer;
    bool isMove = false;

    PlayerInputSystem input;
    Camera mainCam;
    Rigidbody rigid;
    Animator ani;
    Collider collidr;
    Vector3 clickPositon;

    private void Awake()
    {
        input = new PlayerInputSystem();
        rigid = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        collidr = GetComponent<Collider>();
        mainCam = Camera.main;
        groundLayer = LayerMask.NameToLayer("Ground");
    }

    private void OnEnable()
    {
        input.Player.Enable();
        input.Player.Move.performed += OnMouseClick;
        input.Player.Dive.performed += OnDive;
    }


    private void OnDisable()
    {
        input.Player.Dive.performed -= OnDive;
        input.Player.Move.performed -= OnMouseClick;
        input.Player.Disable();
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            Move();
            ani.SetBool("IsMove", isMove);
        }
    }

    private void OnMouseClick(InputAction.CallbackContext _)
    {
        Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());     // 클릭 위치로 나아가는 광선

        // out : 매개변수 한정자 (충돌지점에 대한 정보를 구조체 변수(hit)에 담아준다.)
        // 광선에 맞았는가? && 맞은 오브젝트가 컬라이더를 가지고있는가? && 그 컬라이더의 게임 오브젝트의 레이어와 groundlayer를 비교해서 같으면 0 아니면 1?
        // layer는 int. 즉, 4byte로 32개의 상태를 표현함. 32개의 0과 1을 이용해 0이면 감지하지 않고 1인 레이어만 감지.
        // 마치 크기가 32개인 bool 배열. bool은 1byte. 32개를 표현하기 위해선 32byte. 8배의 차이가 난다.
        // 그래서 layer엔 비트연산자 <<, >> 등을 쓴다.
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider && hit.collider.gameObject.layer.CompareTo(groundLayer) == 0)
        {
            clickPositon = hit.point;
            isMove = true;
        }
    }

    private void OnDive(InputAction.CallbackContext _)
    {
        collidr.isTrigger = true;
        ani.applyRootMotion = true;
        ani.SetTrigger("Dive");
    }

    void OptionOff()
    {
        collidr.isTrigger = false;
        ani.applyRootMotion = false;
        //transform.up = Vector3.up;

        rigid.angularVelocity = Vector3.zero;
    }

    void Move()
    {
        Vector3 dir = clickPositon - transform.position;
        if (dir.sqrMagnitude > 0.1f)
        {
            rigid.MovePosition(rigid.position + moveSpeed * Time.fixedDeltaTime * dir.normalized);
        }
        else
        {
            isMove = false;
            ani.SetBool("IsMove", isMove);
        }
        rigid.rotation = Quaternion.Slerp(rigid.rotation, Quaternion.LookRotation(dir.normalized), rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(clickPositon, 0.5f);
    }
}
