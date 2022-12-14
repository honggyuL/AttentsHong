using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {Arrow, Weapon, Coin};
    public Type type;
    public int value;

    void Update()
    {
        transform.Rotate(Vector3.up * 10.0f * Time.deltaTime);
    }
}
