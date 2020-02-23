using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObjectAndDestroy : MonoBehaviour {
    [SerializeField] private GameObject gameObjectToEnable;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Player")) {
            gameObjectToEnable.SetActive(true);
            Destroy(this);
        }
    }
}
