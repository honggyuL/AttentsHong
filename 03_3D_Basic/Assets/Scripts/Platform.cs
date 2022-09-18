using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    //1.1. 발판위에 있는 트리거로 올라온 대상 확인하기
   //1.2. 목적지의 transform을 맴버 변수로 가지고 있어야 한다.
   //1.3. 목적지까지 일정한 속도로 움직인다.
   //1.4. (도전과제) 플레이어가 발판에 올라간 상태로 아이템 사용키(f키) 를 누르면 작동한다.


    public float moveSpeed = 1.0f;
    public Transform desPos;
    public Transform StartPos;
    public Transform EndPos;

    private void Awake()
    {
        
    }

    private void Update()
    {
        transform.position = transform.position + moveSpeed * Time.deltaTime * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
