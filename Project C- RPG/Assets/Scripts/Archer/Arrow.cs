using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject Target;
    public Transform StarArrowPos;
    public float ArrowSpeed = 10.0f;
    public int Damage;

    private void Start()
    {
        // 타겟 = Archer의 타겟
        Target = GameObject.Find("Archer").GetComponent<ArcherAttack>().myTarget;
    }

    private void Update()
    {
        if(Target != null)
        {
            // 타겟의 거리까지 3초걸린다.
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 닿은 오브젝트 이름이 Enemy일 때
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy")))
        {
            Destroy(this.gameObject);   // 화살 삭제
        }
    }
}
