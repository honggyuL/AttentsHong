using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapSticky : TrapBase
{
    public float speedDebuff = 0.1f;
    public float duration = 3.0f;

    float originalSpeed = 0.0f;
    Player player = null;

    ParticleSystem ps;

    private void Awake()
    {
        ps = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    protected override void TrapActivate(GameObject target)
    {
        if(player == null)
        {
            player = target.GetComponent<Player>();
            originalSpeed = player.moveSpeed;
            player.moveSpeed *= speedDebuff;
            ps.Play();
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(player == null)
            {
                StartCoroutine(ReleaseDebuff());
            }
        }
    }

    IEnumerator ReleaseDebuff()
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed = originalSpeed;
        originalSpeed = 0.0f;
        player = null;
    }
}
