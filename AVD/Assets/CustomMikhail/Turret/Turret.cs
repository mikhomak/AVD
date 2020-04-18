using System;
using UnityEngine;

public class Turret : MonoBehaviour {
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float selfDestructionTime = 10f;
    [SerializeField] private float selfDestructionTimer = 0f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform rightGun;
    [SerializeField] private Transform leftGun;
    [SerializeField] private bool shooting = false;
    [SerializeField] private ParticleSystem leftShootParticleSystem;
    [SerializeField] private ParticleSystem rightShootParticleSystem;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject rightSmoke;
    [SerializeField] private GameObject leftSmoke;
    [SerializeField] private Animator animator;
    private static readonly int SelfDestraction = Animator.StringToHash("selfDestraction");

    private void Start() {
        animator = GetComponentInParent<Animator>();
    }

    private void FixedUpdate() {
        selfDestructionTimer += Time.deltaTime;
        if (selfDestructionTimer >= selfDestructionTime) {
            setSelfDestruction();
            return;
        }
        if (shooting) {
            timer += Time.deltaTime;
            if (timer >= fireRate) {
                leftShootParticleSystem.Emit(10);
                rightShootParticleSystem.Emit(10);
                Instantiate(projectilePrefab, leftGun.position, transform.rotation);
                Instantiate(projectilePrefab, rightGun.position, transform.rotation);
                timer = 0;
            }
        }
    }

    public void startShooting() {
        shooting = true;
        rightSmoke.SetActive(true);
        leftSmoke.SetActive(true);
    }

    public void selfDestroy() {
        shooting = false;
        explosion.SetActive(true);
        rightSmoke.SetActive(false);
        leftSmoke.SetActive(false);
    }

    private void setSelfDestruction() {
        animator.SetTrigger(SelfDestraction);
        Destroy(this, 2f);
    }
}