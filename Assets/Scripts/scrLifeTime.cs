using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrLifeTime : MonoBehaviour
{
    public float time=3;

    void Start()
    {
        Destroy(gameObject, time);
    }
}
