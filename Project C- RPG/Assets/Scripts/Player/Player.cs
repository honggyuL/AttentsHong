using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] Weapons;
    public bool[] hasWeapons;

    public int arrow;
    public int gold;
    float hAxis;
    float vAxis;

    bool sDown;
    bool wDown;
    bool jDown;
    bool iDown;

    float fireDelay;
    bool fDown;
    bool isFireReady = true;

    bool isJump;

    Vector3 moveVec;

    GameObject nearObject;
    Weapon equipWeapon;

    Rigidbody rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Attack();
        Interation();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        iDown = Input.GetButtonDown("Interation");
        fDown = Input.GetButtonDown("Fire1");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (!isFireReady)
        {
            moveVec = Vector3.zero;
        }
        

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec); // 나아가는 방향을 본다
    }

    void Jump()
    {
        if(jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            isJump = true;
        }
    }

    void Attack()
    {
        if(equipWeapon == null)
        {
            return;
        }
        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.attackSpeed < fireDelay;

        if(fDown && isFireReady && !isJump)
        {
            equipWeapon.Use();
            anim.SetTrigger(equipWeapon.type == Weapon.Type.Warrior ? "Attack" : "Shot");
            fireDelay = 0;
        }
    }

    void Swap()
    {
        
        // 무기 착용 바꾸기

        if (sDown && !isJump)
        {
            if(equipWeapon != null)
            {
                equipWeapon.gameObject.SetActive(false);
            }
            
        }
    }

    void Interation()
    {
        // 줍는다
        // 애니메이션 넣어야함
        if(iDown && nearObject != null && !isJump)
        {
            if(nearObject.tag == "Weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                

                Destroy(nearObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            Item itme = other.GetComponent<Item>();
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Weapon")
        {
            nearObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Weapon")
        {
            nearObject = null;
        }   
    }
}
