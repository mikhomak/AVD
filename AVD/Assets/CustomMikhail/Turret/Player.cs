using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private GameObject ball;
    [SerializeField] private Vector3 moveDirection;

    void Update() {
        
        if (Input.GetButtonDown("Fire1")) {
            var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 1000);
            var projectile = Instantiate(ball, cameraTransform.position, Quaternion.identity);
            projectile.transform.LookAt(hit.point);
        }
    }

}