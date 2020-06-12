using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBlob : MonoBehaviour
{
    Rigidbody rdb;
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("bati");
        rdb.isKinematic = true;
    }
}
