using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody rbd;
    [SerializeField] private GameObject turret;


    void Start() {
        rbd = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        rbd.AddForce(speed * transform.forward);
    }

    private void OnTriggerEnter(Collider other) {
        Instantiate(turret, transform.position, Quaternion.identity);
        Destroy(this);
    }
}