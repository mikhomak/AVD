using System;
using CreatorKitCodeInternal;
using UnityEngine;
using UnityEngine.Playables;

public class Chest : MonoBehaviour {
    [SerializeField] private GameObject timelineGO;
    private PlayableDirector timeline;

    private void Start() {
        timeline = timelineGO.GetComponent<PlayableDirector>();
    }

    private void FixedUpdate() {
        if (timeline.state == PlayState.Playing) {
            CharacterControl.Instance.transform.position = transform.position;
            CharacterControl.Instance.m_Agent.speed = 0;
        }
        else {
            CharacterControl.Instance.m_Agent.speed = 10f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CharacterControl.Instance.Data.invincible = true;
            CharacterControl.Instance.turrets = 3;
            UISystem.Instance.UpdateTurrets(3);
            timeline.Play();
        }
    }
}