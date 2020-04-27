using CreatorKitCodeInternal;
using UnityEngine;
using UnityEngine.Playables;

public class Chest : MonoBehaviour {
    [SerializeField] private GameObject timelineGO;
    private PlayableDirector timeline;

    private void Start() {
        timeline = timelineGO.GetComponent<PlayableDirector>();
    }


    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            timeline.Play();
            CharacterControl.Instance.turrets = 3;
            UISystem.Instance.UpdateTurrets(3);
            Destroy(gameObject, 5f);
            var position = transform.position;
            CharacterControl.Instance.m_Agent.speed = 0.01f;
            CharacterControl.Instance.Speed = 1f;
            CharacterControl.Instance.m_Agent.destination = position;
            CharacterControl.Instance.Data.invincible = true;
            timeline.stopped += stoped;
        }
    }

    private void stoped(PlayableDirector s) {
        CharacterControl.Instance.m_Agent.speed = 10;
        CharacterControl.Instance.Speed = 10f;
        CharacterControl.Instance.Data.invincible = false;
    }
}