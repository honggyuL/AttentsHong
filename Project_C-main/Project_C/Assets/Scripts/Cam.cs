using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    GameObject cameraTarget;

    private void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector3 pos = new Vector3(cameraTarget.transform.position.x, cameraTarget.transform.position.y + 5, cameraTarget.transform.position.z - 5);

        transform.position = pos;
    }

}
