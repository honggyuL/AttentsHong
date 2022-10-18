using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float ArrowSpeed = 5.0f;
    public float lifeTime = 3.0f;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(ArrowSpeed * Time.deltaTime * Vector3.forward, Space.Self);
    }


}
