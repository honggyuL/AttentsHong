using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBase : MonoBehaviour
{
    // Collider trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TrapActivate(other.gameObject);
        }    
    }

    protected virtual void TrapActivate(GameObject target)
    {
    }
}
