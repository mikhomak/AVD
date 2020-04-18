using System;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    [SerializeField] private Rigidbody rbd;
    [SerializeField] private float speed = 15f;

    void Start() {
        Destroy(this, 5f);
        rbd = GetComponent<Rigidbody>();
        rbd.useGravity = false;
    }

    private void FixedUpdate() {
        rbd.velocity = transform.forward * speed;
    }
}