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
            var position = transform.position;
            CharacterControl.Instance.transform.position = position;
            CharacterControl.Instance.m_Agent.speed = 0;
            CharacterControl.Instance.m_Agent.destination = position;
            CharacterControl.Instance.Data.invincible = true;
        }
        else {
            CharacterControl.Instance.m_Agent.speed = 10f;
            CharacterControl.Instance.Data.invincible = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CharacterControl.Instance.turrets = 3;
            UISystem.Instance.UpdateTurrets(3);
            timeline.Play();
            Destroy(gameObject, 5f);
        }
    }
}