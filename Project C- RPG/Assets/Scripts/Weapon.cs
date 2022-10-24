using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Warrior, Archer};
    public Type type;
    public float damage;
    public float attackSpeed;
    public Collider Collider;
    public Transform arrowPos;
    public GameObject arrow;

    public void Use()
    {
        if (type == Type.Warrior)
        {
            StopCoroutine("Slash");
            StartCoroutine("Slash");
        }
        else if (type == Type.Archer)
        {
            StartCoroutine("Shot");
        }
    }

    IEnumerator Slash()
    {
        yield return new WaitForSeconds(2.0f);
        Collider.enabled = true;
    }

    IEnumerator Shot()
    {
        GameObject instantArrow = Instantiate(arrow, arrowPos.position, arrowPos.rotation);
        Rigidbody arrowRigid = instantArrow.GetComponent<Rigidbody>();
        arrowRigid.velocity = arrowPos.forward * 50.0f;
        yield return null;
    }
}
