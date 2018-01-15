using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Losowyobrot : MonoBehaviour {

    public float Spadek;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.angularVelocity = Random.insideUnitSphere * Spadek;

    }
}
