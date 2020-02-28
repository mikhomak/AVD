using CustomMikhail._2d_Sunny_Lands_practy.Scripts.Boss;
using UnityEngine;

public class Platform : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        IRacoon racoon = other.GetComponent<IRacoon>();
        if (racoon != null) {
            racoon.takeDamage(500f);
        }
    }
}