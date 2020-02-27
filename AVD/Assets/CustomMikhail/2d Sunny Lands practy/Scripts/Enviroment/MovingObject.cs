using System;
using UnityEngine;

namespace CustomMikhail._2d_Sunny_Lands_practy.Scripts.Enviroment {
    public class MovingObject : MonoBehaviour {
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;

        private void Start() {
            Destroy(gameObject, lifeTime);
        }

        private void FixedUpdate() {
            transform.position += direction * (speed * Time.deltaTime);
        }
    }
}