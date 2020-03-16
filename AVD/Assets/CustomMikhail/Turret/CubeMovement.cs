using System;
using UnityEngine;

public class CubeMovement : MonoBehaviour {
    [SerializeField] private Rigidbody rbd;

    [SerializeField] private Animator animator;
    [SerializeField] private float timer;
    [SerializeField] private float time = 5f;
    [SerializeField] private float speed = 25f;
    [SerializeField] private int direction = 1;
    private static readonly int TookDamage = Animator.StringToHash("tookDamage");

    void Start() {
        rbd = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        timer += Time.deltaTime;
        if (timer >= time) {
            direction *= -1;
            timer = 0;
            return;
        }

        rbd.velocity = transform.right * (speed * direction);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag($"Bullet")) {
            animator.SetTrigger(TookDamage);
            Destroy(other.gameObject);
        }
    }
}