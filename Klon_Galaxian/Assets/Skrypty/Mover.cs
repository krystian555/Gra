﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float Predkosc;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();  

        rb.velocity = Vector3.forward * Predkosc;
    }
}
